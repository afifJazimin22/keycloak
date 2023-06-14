using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keycloak.AuthServices.Sdk.Admin.Models;

namespace KeycloakMicroservice.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUser();
    }
}