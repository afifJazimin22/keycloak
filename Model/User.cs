using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeycloakMicroservice.Model
{
    public class User
    {
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
    }
}