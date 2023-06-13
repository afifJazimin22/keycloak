using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keycloak.AuthServices.Sdk.Admin.Models;

namespace KeycloakMicroservice.Services
{
    public class UserMicroservice
    {
        private readonly IConfiguration config;

        public UserMicroservice(IConfiguration config)
        {
            this.config = config;
        }

        // public async Task<User> GetToken(User user)
        // {
            
        // } 
    }
}