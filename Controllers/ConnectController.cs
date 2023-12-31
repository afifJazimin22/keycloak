using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeycloakMicroservice.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace KeycloakMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAngularOrigins")]
    public class ConnectController : ControllerBase
    {
        private readonly IConnectService _connectService;

        public ConnectController(IConnectService connectService)
        {
            _connectService = connectService;
        }
        [EnableCors("AllowAngularOrigins")]

        [HttpPost("/api/connect")]
        public async Task Connect()
        {
            await _connectService.Connect();
        }
    }
}