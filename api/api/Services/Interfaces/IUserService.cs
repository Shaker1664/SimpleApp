using api.Entities;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services.Interfaces
{
    public interface IUserService
    {
        Task<CreateUser> CreateAsync(CreateUser createUser);
        Task<string> RemoveAsync(string id);
        //Task<EditUser> UpdateAsync(EditUser editUser);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(string id);
    }
}
