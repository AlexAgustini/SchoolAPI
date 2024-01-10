using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Modules.Auth.Dtos;

public class LoginDto
{
    [EmailAddress]
    public string Email { get; set; }
    
    public string Password { get; set; }
}