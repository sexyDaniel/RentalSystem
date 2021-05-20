using PapsCourse.Client.Services.Abstract;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace PapsCourse.Client.Services.Implementations
{
    public class JwtSession:IAccountSession
    {        
        private JwtSecurityToken token;
        public bool IsAuthenticated => token != null;

        public event Action<string> OnAuthenticated;
        public event Action OnLogout;
        
        public void Logout()
        {
            token = null;
            OnLogout.Invoke();
        }

        public void SetSession(string value)
        {
            if (!String.IsNullOrWhiteSpace(value))
            {
                try
                {
                    var handler = new JwtSecurityTokenHandler();
                    token = handler.ReadJwtToken(value);
                    OnAuthenticated.Invoke(token.RawData);
                }
                catch(Exception ex)
                {
                    token = null;
                }
            }            
        }

        public string GetValue(string key)
        {
            return token.Claims.First(c => c.Type == key).Value;
        }
    }
}
