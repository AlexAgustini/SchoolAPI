
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Modules.Core.Database;
using SchoolAPI.Modules.Core.Exceptions;
using SchoolAPI.Modules.Users.Dtos;
using SchoolAPI.Modules.Users.Models;

namespace SchoolAPI.Modules.Users.Repositories;

public class UsersRepository
{
    private readonly DataContext _dataContext;
    
    public UsersRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<User>> FindAll()
    {
        var users = await _dataContext.Users.ToListAsync();
        return users;
    }

    public async Task<User> FindOne(int id)
    {
        var users = await _dataContext.Users
            .FirstOrDefaultAsync(b=> b.Id ==id);
        if (users is null)
        {
            throw new NotFoundException();
        }
        return users;
    }
    public async Task<User?> FindOneByEmail(string email)
    {
        var user = await _dataContext.Users
            .FirstOrDefaultAsync(u=> u.Email == email);
        return user;
    }

    public async Task<User> Create(CreateUserDto user)
    {

        var newUser = new User()
        {
            Name = user.Name,
            Email = user.Email,
            TeacherId = user.TeacherId,
            Hash = user.Password
        };
        
        
        _dataContext.Users.Add(newUser);
        await _dataContext.SaveChangesAsync();

        return newUser;
    }

    public async Task<User> Update(int id, UpdateUserDto user)
    {
        var dbUser = await FindOne(id);
        
        _dataContext.Entry(dbUser).CurrentValues.SetValues(user);
        
        await _dataContext.SaveChangesAsync();
        return dbUser;
    }
    
    public async Task<bool> Delete(int id)
    {
        var dbUser = await FindOne(id);
        _dataContext.Remove(dbUser);
        return await _dataContext.SaveChangesAsync() > 0;
    }

}