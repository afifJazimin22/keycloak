using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeycloakMicroservice.Model;

namespace KeycloakMicroservice.Services
{
    public interface IConnectService
    {
        Task<Token> Connect();
    }
}