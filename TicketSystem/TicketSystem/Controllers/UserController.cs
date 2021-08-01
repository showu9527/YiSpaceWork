using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSystem.Service.Interface;
using TicketSystem.Service.Models;

namespace TicketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("Login")]
        public IActionResult Login(LoginRequest request)
        {
            //TODO: check request parameter

            return Ok(_userService.UserLogin(request));
        }

        [HttpPost("Create")]
        public IActionResult Create()   
        {
            throw new NotImplementedException();
        }

        [HttpPost("Edit")]
        public IActionResult Edit()
        {
            throw new NotImplementedException();
        }

        [HttpPost("Delete")]
        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}
