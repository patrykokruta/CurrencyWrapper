using CurrencyWrapper.Identity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWrapper.Identity.Services
{
    public interface IAuthenticationService
    {
        Task<bool> ValidateUser(UserForAuthentication userForAuth);
        string CreateToken();
    }
}
