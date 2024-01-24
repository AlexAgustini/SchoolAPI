
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Modules.Core.Database;
using SchoolAPI.Modules.Core.Exceptions;
using SchoolAPI.Modules.Users.Dtos;
using SchoolAPI.Modules.Users.Extensions;
using SchoolAPI.Modules.Users.Models;

namespace SchoolAPI.Modules.Users.Repositories;

public class UsersRepository
{
    private readonly DataContext _dataContext;
    
    public UsersRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<UserDto>> FindAll()
    {
        var users = await _dataContext.Users.ToListAsync();

        return users.Select(user => user.ToUserDto()).ToList();
    }

    public async Task<User> FindOne(int id)
    {
        var user = await _dataContext.Users
            .FirstOrDefaultAsync(b=> b.Id ==id);
        if (user is null)
        {
            throw new NotFoundException();
        }

        return user;
    }
    public async Task<User?> FindOneByEmail(string email)
    {
        var user = await _dataContext.Users
            .FirstOrDefaultAsync(u=> u.Email == email);
        return user;
    }

    public async Task<UserDto> Create(CreateUserDto user)
    {

        var newUser = new User()
        {
            Name = user.Name,
            Email = user.Email,
            TeacherId = user.TeacherId,
            Role = user.Role,
            Hash = user.Password,
        };
        
        
        _dataContext.Users.Add(newUser);
        await _dataContext.SaveChangesAsync();

        return newUser.ToUserDto();
    }

    public async Task<UserDto> Update(int id, UpdateUserDto user)
    {

        await _dataContext.Users
            .Where(u=> u.Id == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(u => u.Name, user.Name)
                .SetProperty(u => u.Email, user.Email)
                .SetProperty(u => u.TeacherId, user.TeacherId)
                .SetProperty(u => u.Role, user.Role)
            );
        
        return (await FindOne(id)).ToUserDto();
    }
    
    public async Task<bool> ChangePassword(int id, string newHash)
    {
        var affectedRows= await _dataContext.Users
            .Where(u=> u.Id == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(u => u.Hash, newHash)
            );

        return affectedRows > 0;
    }

    
    public async Task<bool> Delete(int id)
    {
        var dbUser = await FindOne(id);
        _dataContext.Remove(dbUser);
        return await _dataContext.SaveChangesAsync() > 0;
    }

}