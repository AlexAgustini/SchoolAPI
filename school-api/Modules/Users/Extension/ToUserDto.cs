using SchoolAPI.Modules.Users.Dtos;
using SchoolAPI.Modules.Users.Models;

namespace SchoolAPI.Modules.Users.Extensions;

public static class ToUserDtoExtension
{
    public static UserDto ToUserDto(this User user)
    {
        return new UserDto()
        {
            Name = user.Name,
            Email = user.Email,
            TeacherId = user.TeacherId
        };
    }
}