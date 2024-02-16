using SchoolAPI.Modules.Users.Dtos;
using SchoolAPI.Modules.Users.Models;

namespace SchoolAPI.Modules.Users.Extensions;

public static class ToUserDtoExtension
{
    public static UserDto ToUserDto(this User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role
        };
    }
}