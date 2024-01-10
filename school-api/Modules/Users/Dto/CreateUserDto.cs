using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Modules.Users.Dtos;

public class CreateUserDto
{
    public string Name { get; set; }
    
    public string Password { get; set; }
    public string Email { get; set; }
    
    public int? TeacherId { get; set; }
}