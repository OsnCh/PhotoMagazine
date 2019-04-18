using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoMagazine.Business.Services.Interfaces;
using PhotoMagazine.ViewModels.ViewModels.Account;
using PhotoMagazine.ViewModels.ViewModels.Base;

namespace PhotoMagazine.Api.Controllers.Api
{
    [Authorize]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody]RegistrationViewModel model)
        {
            var (result, msg) = await _accountService.Registration(model);

            if (result)
            {
                return Ok(msg);
            }

            return BadRequest(msg);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var (msg, data) = await _accountService.Login(model);
            
            if(data == null)
            {
                return BadRequest(msg);
            }

            return Ok(new ResponseDataViewModel(msg, data));
        }


        [AllowAnonymous]
        [HttpGet("confirmationcode/send/{userId}")]
        public async Task<IActionResult> SendConfirmationCode([FromRoute] string userId)
        {
            var (result, msg) = await _accountService.SendConfirmedCode(userId);

            if (!result)
            {
                return BadRequest(msg);
            }

            return Ok(msg);
        }

        [AllowAnonymous]
        [HttpGet("confirmationcode/set/{userId}/{code}")]
        public async Task<IActionResult> SendConfirmationCode([FromRoute] string userId, [FromRoute] string code)
        {
            var (msg, data) = await _accountService.SetConfirmedCode(userId, code);

            if (data == null)
            {
                return BadRequest(msg);
            }

            return Ok(new ResponseDataViewModel(msg, data));
        }

    }
}