using Microsoft.EntityFrameworkCore;
using SchoolAPI.Modules.Core.Database;
using SchoolAPI.Modules.Core.Exceptions;
using SchoolAPI.Modules.Teachers.Dto;
using SchoolAPI.Modules.Teachers.Models;

namespace SchoolAPI.Modules.Teachers.Repositories;

public class TeachersRepository
{
    private readonly DataContext _dataContext;
    
    public TeachersRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<Teacher>> FindAll()
    {
        var teachers = await _dataContext.Teachers.ToListAsync();
        return teachers;
    }

    public async Task<Teacher> FindOne(int id)
    {
        var teacher = await _dataContext.Teachers
            .FirstOrDefaultAsync(b=> b.Id ==id);
        if (teacher is null)
        {
            throw new NotFoundException();
        }
        return teacher;
    }

    public async Task<Teacher> Create(CreateTeacherDto teacher)
    {
        var newTeacher = new Teacher()
        {
            Name = teacher.Name,
            Age = teacher.Age,
            Email = teacher.Email,
            Courses = teacher.Courses
        };
        
        
        _dataContext.Teachers.Add(newTeacher);
        await _dataContext.SaveChangesAsync();

        return newTeacher;
    }

    public async Task<Teacher> Update(int id, CreateTeacherDto createTeacher)
    {
        var dbTeacher = await FindOne(id);
        
            _dataContext.Entry(dbTeacher).CurrentValues.SetValues(createTeacher);
        
        await _dataContext.SaveChangesAsync();
        return dbTeacher;
    }
    
    public async Task<Teacher> Delete(int id)
    {
        var dbTeacher = await FindOne(id);
        _dataContext.Remove(dbTeacher);
        await _dataContext.SaveChangesAsync();
        return dbTeacher;
    }

}