using API.DTO;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class UsersController (IUserRepository userRepository) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<MembersDto>>> GetUsers()
        {
            List<MembersDto> users = await userRepository.GetAllMembersAsync();
            if(users.Count is 0) return NotFound("No users found");
            return users;
        }
        [HttpGet("{username}")]
        public async Task<ActionResult<MembersDto>> GetUser(string username)
        {
            MembersDto? user = await userRepository.GetMemberAsync(username);
            if(user == null) return NotFound("No user found");
            return user;
        }
    }
}
