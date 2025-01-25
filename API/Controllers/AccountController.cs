using System;
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController(DataContext context) : BaseApiController
{
    [HttpPost]
    public async Task<ActionResult<AppUsers>> Register(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.Username)) 
            return BadRequest("Username is taken");
        using var hmc = new HMACSHA512();
        AppUsers user = new()
        {
            UserName = registerDto.Username.ToLower(),
            PasswordHash = hmc.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmc.Key
        };
        context.Users.Add(user);

        await context.SaveChangesAsync();
        return user;

    }

    private async Task<bool> UserExists(string username)
    {
        return await context.Users.AnyAsync(x => x.UserName == username.ToLower());
    }   

}
