using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Client.Services.Abstract
{    
    public interface IAccountSession
    {
        bool IsAuthenticated { get; }
        void SetSession(string value);
        void Logout();
        event Action<string> OnAuthenticated;
        event Action OnLogout;
    }
}
