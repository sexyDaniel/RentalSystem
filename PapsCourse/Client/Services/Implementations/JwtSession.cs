using PapsCourse.Client.Services.Abstract;
using System;

namespace PapsCourse.Client.Services.Implementations
{
    public class JwtSession:IAccountSession
    {
        private string jwt;
        public bool IsAuthenticated => !String.IsNullOrEmpty(jwt);

        public event Action<string> OnAuthenticated;
        public event Action OnLogout;
        
        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void SetSession(string value)
        {
            if (!String.IsNullOrWhiteSpace(value))
            {
                jwt = value;
                OnAuthenticated.Invoke(jwt);
            }
            
        }
    }
}
