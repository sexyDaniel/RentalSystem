using System;
using System.Collections.Generic;
using System.Text;

namespace PapsCourse.Shared.Models
{
    public class JwtTokens
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
