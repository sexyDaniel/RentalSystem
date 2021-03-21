using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Shared.Account
{
    public class JwtTokens
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
