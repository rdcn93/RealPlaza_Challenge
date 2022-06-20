using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RealPlazaChallenge.Application.InputModel;
using RealPlazaChallenge.Application.Services.Security;
using RealPlazaChallenge.Application.Services.User;
using System;
using System.Threading.Tasks;

namespace RealPlazaChallenge.API.Controllers
{
    [Route("api/security")]
    [EnableCors("permit")]
    public class SecurityController : Controller
    {
        private readonly ISecurityService _securityService;
        private readonly IUserService _userService;

        public SecurityController(ISecurityService securityService, IUserService userService)
        {
            _securityService = securityService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(UserModel login)
        {
            if(login.email != null && login.email != String.Empty && login.password != null && login.password != String.Empty)
            {
                var validation = await IsValidUser(login);

                if (validation)
                    return Ok();
                else
                    return NotFound();
            }            

            return NotFound();
        }

        private async Task<bool> IsValidUser(UserModel login)
        {
            var user = await _userService.GetUserByEmail(login.email);
            bool isValid = false;

            if(user != null)
                isValid = _securityService.Check(user.password, login.password);
                        
            return isValid;
        }

    }
}
