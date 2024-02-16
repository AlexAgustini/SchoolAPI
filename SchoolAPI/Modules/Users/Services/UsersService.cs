
using System.Security.Claims;
using SchoolAPI.Modules.Core.Exceptions;
using SchoolAPI.Modules.Teachers.Services;
using SchoolAPI.Modules.Users.Dtos;
using SchoolAPI.Modules.Users.Enums;
using SchoolAPI.Modules.Users.Extensions;
using SchoolAPI.Modules.Users.Repositories;

namespace SchoolAPI.Modules.Users.Services;

public class UsersService
{

    private readonly TeachersService _teachersService;

    private readonly UsersRepository _usersRepository;
    
    public UsersService(UsersRepository usersRepository, TeachersService teachersService)
    {
        _usersRepository = usersRepository;
        _teachersService = teachersService;
    }
    
    public async Task<List<UserDto>> FindAll()
    {
        return await _usersRepository.FindAll();
    } 
    public async Task<UserDto> FindOne(int id)
    {
        return (await _usersRepository.FindOne(id)).ToUserDto();
    } 
    public async Task<UserDto> Create(CreateUserDto user, ClaimsPrincipal loggedUser)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        
        return await _usersRepository.Create(user);
    }

    public async Task<bool> ChangePassword(int id, ChangePasswordDto data)
    {
        var newHash = BCrypt.Net.BCrypt.HashPassword(data.Password);

        return await _usersRepository.ChangePassword(id, newHash);
    }
        
    
    public async Task<UserDto> Update(int id, UpdateUserDto user)
    {
        return await _usersRepository.Update(id, user); 
    } 
    public async Task<bool> Delete(int id)
    {
        return await _usersRepository.Delete(id);
    }
}