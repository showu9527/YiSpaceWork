using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using TicketSystem.Common.Auth;
using TicketSystem.Service.Interface;
using TicketSystem.Service.Models;

namespace TicketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(LoginRequest request)
        {
            //TODO: check request parameter

            return Ok(_userService.UserLogin(request));
        }

        [HttpPost("Create")]
        public IActionResult Create()
        {
            var temp = this.User;
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

        /// <summary>
        /// 取得當前玩家
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static CurrentUser GetCurrentUser(HttpContext context)
        {
            var currentPlayer =
                JsonConvert.DeserializeObject<CurrentUser>(context.Request?.Headers["CurrentUser"].ToString());
            if (currentPlayer == default)
            {
                throw new Exception();
            }

            return currentPlayer;
        }
    }
}
