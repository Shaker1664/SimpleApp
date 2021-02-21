using api.Entities;
using api.Models;
using api.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public UserService(UserManager<User> userManager, IMapper mapper, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<CreateUser> CreateAsync(CreateUser createUser)
        {
            var userExists = await _userManager.FindByNameAsync(createUser.UserName);
            if (userExists != null)
                return null;
            var user = _mapper.Map<User>(createUser);
            var result = await _userManager.CreateAsync(user, createUser.Password);
            if (!result.Succeeded)
                return null;
            await _userManager.AddToRolesAsync(user, createUser.Roles);
            return createUser;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _context.Users
                .OrderBy(x => x.UserName)
                .ToListAsync();

            return users;
        }

        public async Task<User> GetById(string id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return null;
            return user;
        }

        public async Task<string> RemoveAsync(string id)
        {
            var userExist = await _userManager.FindByIdAsync(id);
            if (userExist == null)
                return null;
            await _userManager.DeleteAsync(userExist);
            return userExist.UserName;
        }

        //public async Task<EditUser> UpdateAsync(EditUser editUser)
        //{
        //    var user = await _userManager.FindByNameAsync(editUser.UserName);
        //    if (user != null)

        //}
    }
}
