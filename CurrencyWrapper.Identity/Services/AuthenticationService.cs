using CurrencyWrapper.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWrapper.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private IdentityUser _user;

        public AuthenticationService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> ValidateUser(UserForAuthentication userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName);
            return (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));
        }

        public string CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var tokenOptions = GenerateTokenOptions(signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("ValidIssuer").Value,
                audience: jwtSettings.GetSection("ValidAudience").Value,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("Expires").Value)),
                signingCredentials: signingCredentials
                );
            return tokenOptions;
        }
    }
}
