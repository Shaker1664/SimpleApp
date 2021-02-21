using api.Authentication;
using api.Models;
using api.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _service.GetAll();

            var mappedUser = _mapper.Map<IEnumerable<UserIndex>>(users);

            return Ok(mappedUser);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.User)]
        public async Task<ActionResult> GetUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(new { Message = "Id cannot be null" });
            }
            var user = await _service.GetById(id);

            if (user == null)
            {
                return NotFound(new { Message = "User not found" });
            }

            var mappedUser = _mapper.Map<UserIndex>(user);

            return Ok(mappedUser);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<CreateUser>> Create(CreateUser createUser)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.CreateAsync(createUser);

                if (response ==null)
                {
                    return BadRequest(new { Message = "User creation failed! Please check user details and try again" });
                }
                return Ok(response);
            }
            return BadRequest(new { Message = "Invalid Product Object" });
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteUser(string id)
        {
            var result = await _service.RemoveAsync(id);
            if (result == null)
            {
                return NotFound(new { Message = "User not found" });
            }
            return Ok(result);
        }

    }
}
