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

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [EnableCors("AllowAngularOrigins")]
        [HttpGet("/api/users")]
        public async Task<IActionResult> GetUsersAsync()
        {
            return Ok(await _userService.GetUser());
        }
    }
}