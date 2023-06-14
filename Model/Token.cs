using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeycloakMicroservice.Model
{
    public class Token
    {
        public string? access_token { get; set; }
        public string expires_in { get; set; }
        public string refresh_expires_in { get; set; }
        public string token_type { get; set; }
        public int not_before_policy { get; set; }
        public string scope { get; set; }
    }
}