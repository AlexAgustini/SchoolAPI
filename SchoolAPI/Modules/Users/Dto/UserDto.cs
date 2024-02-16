using SchoolAPI.Modules.Users.Enums;

namespace SchoolAPI.Modules.Users.Dtos;

public class UserDto
{
    public required int Id { get; set; }
    
    public required string Name { get; set; }
        
    public required string Email { get; set; }
    
    public required UserRoleEnum Role { get; set; }
    
}