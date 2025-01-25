using System;
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AccountController(DataContext context) : BaseApiController
{
    [HttpPost]
    public async Task<ActionResult<AppUsers>> Register(RegisterDto registerDto)
    {
        using var hmc = new HMACSHA512();
        AppUsers user = new AppUsers
        {
            UserName = registerDto.Username,
            PasswordHash = hmc.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmc.Key
        };
        context.Users.Add(user);

        await context.SaveChangesAsync();
        return user;

    }

}
