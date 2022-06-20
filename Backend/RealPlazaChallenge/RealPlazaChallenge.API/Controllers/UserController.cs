using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RealPlazaChallenge.Application.InputModel;
using RealPlazaChallenge.Application.Services.Security;
using RealPlazaChallenge.Application.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealPlazaChallenge.API.Controllers
{
    [Route("api/user")]
    [EnableCors("permit")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISecurityService _securityService;
        public UserController(IUserService userService, ISecurityService securityService)
        {
            _userService = userService;
            _securityService = securityService;
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel userInputModel)
        {
            if(userInputModel.password != null && userInputModel.password != String.Empty)
            {
                string encriptedPassword = _securityService.Hash(userInputModel.password);

                userInputModel.password = encriptedPassword;
            }
            
            var id = await _userService.AddUser(userInputModel);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

    }
}
