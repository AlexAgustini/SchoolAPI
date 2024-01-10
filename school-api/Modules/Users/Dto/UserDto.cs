namespace SchoolAPI.Modules.Users.Dtos;

public class UserDto
{
    public required string Name { get; set; }
        
    public required string Email { get; set; }
    
    public int? TeacherId { get; set; }
}