using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PapsCourse.Server.Interfaces;
using PapsCourse.Shared.Models;
using PapsCourse.Shared.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using PapsCourse.Server.Models.Services;
using PapsCourse.Server.Models;

namespace PapsCourse.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserRepository userRepository;
        public AccountController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        public Response Registration([FromBody]RegistrationRequest registrationRequest) 
        {
            var response = new Response() { Errors = new List<string>()};
            if (UniqueEmail(registrationRequest))
            {
                if (UniquePhone(registrationRequest))
                {
                    var salt = CriptoService.GetRandomBytes();
                    userRepository.Add(new User { 
                        FirstName = registrationRequest.Name,
                        LastName = registrationRequest.Lastname,
                        Patronymic = registrationRequest.Patronymic,
                        Email = registrationRequest.Email,
                        Phone = registrationRequest.PhoneNumber,
                        PasswordHash = Convert.ToBase64String(CriptoService.Pbkdf2(registrationRequest.Password, salt)),
                        Salt = Convert.ToBase64String(salt)
                    });
                }
                else
                {
                    response.Errors.Add("Такой телефон уже зарегестрирован");
                }
            }
            else 
            {
                response.Errors.Add("Такой Email уже зарегестрирован");
            }
            return response;
        }

        [HttpPost]
        public Response Login([FromBody]AutenticationRequest request) 
        {
            var response = new Response() { Errors = new List<string>() };
            var user = userRepository.SearchByEmail(request.Email);
            if (user!=null)
            {
                var passwordHash = Convert.ToBase64String(CriptoService.Pbkdf2(request.Password, Convert.FromBase64String(user.Salt)));
                if (passwordHash == user.PasswordHash)
                {
                    response.Data = JsonSerializer.Serialize(new JwtTokens {AccessToken= JwtToken.GetToken(user) });
                }
                else 
                {
                    response.Errors.Add("Неверный пароль");
                }
            }
            else 
            {
                response.Errors.Add("Неверный Email");
            }
            return response;
        }

        private bool UniqueEmail(RegistrationRequest registrationRequest) => 
            userRepository.Users.FirstOrDefault(rr => rr.Email == registrationRequest.Email) == null;
    

        private bool UniquePhone(RegistrationRequest registrationRequest)=>
            userRepository.Users.FirstOrDefault(rr => rr.Phone == registrationRequest.PhoneNumber) == null;
       
    }
}
