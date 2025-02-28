using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    [StringLength(20, MinimumLength = 8)]
    [RegularExpression(
        "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,15}$",
        ErrorMessage = "Password must have 1 uppercase, 1 lowercase, 1 number, and at least 8 characters"
    )]
    public string Password { get; set; } = string.Empty;
}
