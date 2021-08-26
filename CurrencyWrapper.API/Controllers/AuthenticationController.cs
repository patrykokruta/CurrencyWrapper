using CurrencyWrapper.Common.Logger;
using CurrencyWrapper.Identity.Models;
using CurrencyWrapper.Identity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyWrapper.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly ILoggerService _loggerService;

        public AuthenticationController(UserManager<IdentityUser> userManager,
            IAuthenticationService authenticationService,
            ILoggerService loggerService)
        {
            _userManager = userManager;
            _authenticationService = authenticationService;
            _loggerService = loggerService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistration userForRegistration)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new IdentityUser()
            {
                UserName = userForRegistration.UserName,
                Email = userForRegistration.Email
            };
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthentication user)
        {
            if (!await _authenticationService.ValidateUser(user))
            {
                _loggerService.Log($"[{nameof(AuthenticationController)}]: Authentication failed. Wrong user name or password.", LogLevel.Normal);
                return Unauthorized();
            }
            return Ok(new { Token = _authenticationService.CreateToken() });
        }
    }
}
