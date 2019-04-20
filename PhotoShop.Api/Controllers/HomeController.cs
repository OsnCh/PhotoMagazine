using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PhotoMagazine.Business.Commons;

namespace PhotoMagazine.Api.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApiInformation _information;

        public HomeController(IOptions<ApiInformation> information)
        {
            _information = information.Value;
        }

        public IActionResult Index()
        {
            return Ok(_information.ToString());
        }
    }
}