using System.Security.Claims;
using API.DTO;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class UsersController (IUserRepository userRepository, IMapper mapper) : BaseApiController
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

        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (username is null)
            {
                return BadRequest("Invalid username");
            }
            AppUsers? user = await userRepository.GetUserByUsernameAsync(username);
            if (user is null)
            {
                return BadRequest("No user found");
            }
            mapper.Map(memberUpdateDto, user);
            if (await userRepository.SaveAllAsync())
            {
                return NoContent();
            }
            return BadRequest("Failed to update user");
        }
    }
}
