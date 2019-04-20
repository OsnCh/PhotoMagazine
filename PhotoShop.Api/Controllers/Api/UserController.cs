using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoMagazine.Business.Auth.Extensions;
using PhotoMagazine.Business.Services.Interfaces;
using PhotoMagazine.ViewModels.ViewModels.Base;

namespace PhotoMagazine.Api.Controllers.Api
{
    [Authorize]
    [Route("api/user")]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("home")]
        public async Task<IActionResult> GetUserHome()
        {
            var userId = User.Identity.GetUserId();
            var (msg, data) = await _userService.GetUserHomeView(userId);
            return Ok(new ResponseDataViewModel(msg, data));
        }


    }
}