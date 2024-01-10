
using SchoolAPI.Modules.Users.Dtos;
using SchoolAPI.Modules.Users.Models;
using SchoolAPI.Modules.Users.Repositories;

namespace SchoolAPI.Modules.Users.Services;

public class UsersService
{

    private readonly UsersRepository _usersRepository;
    
    public UsersService(UsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    
    public async Task<List<User>> FindAll()
    {
        return await _usersRepository.FindAll();
    } 
    public async Task<User> FindOne(int id)
    {
        return await _usersRepository.FindOne(id);
    } 
    public async Task<User> Create(CreateUserDto user)
    {

        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        
        return await _usersRepository.Create(user);
    } 
    public async Task<User> Update(int id, UpdateUserDto user)
    {
        return await _usersRepository.Update(id, user); 
    } 
    public async Task<bool> Delete(int id)
    {
        return await _usersRepository.Delete(id);
    }
}