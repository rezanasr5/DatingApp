using System;
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AccountController(DataContext context) : BaseApiController
{
    [HttpPost]
    public async Task<ActionResult<AppUsers>> Register(string username, string password)
    {
        using var hmc = new HMACSHA512();
        AppUsers user = new AppUsers
        {
            UserName = username,
            PasswordHash = hmc.ComputeHash(Encoding.UTF8.GetBytes(password)),
            PasswordSalt = hmc.Key
        };
        context.Users.Add(user);

        await context.SaveChangesAsync();
        return user;

    }

}
