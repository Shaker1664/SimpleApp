using api.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterModel> RegsiterAsync(RegisterModel model);
        Task<RegisterModel> RegisterAdminAsync(RegisterModel model);
        Task<string> Login(LoginModel model);
    }
}
