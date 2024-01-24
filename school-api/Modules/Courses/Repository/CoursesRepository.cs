using Microsoft.EntityFrameworkCore;
using SchoolAPI.Modules.Core.Database;
using SchoolAPI.Modules.Core.Exceptions;
using SchoolAPI.Modules.Courses.Dtos;
using SchoolAPI.Modules.Courses.Models;

namespace SchoolAPI.Modules.Courses.Repositories;

public class CoursesRepository
{
    private readonly DataContext _dataContext;
    
    public CoursesRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<Course>> FindAll()
    {
        var courses = await _dataContext.Courses.ToListAsync();
        return courses;
    }

    public async Task<Course?> FindOne(int id)
    {
        var course = await _dataContext.Courses
            .Include(c=> c.Teacher)
            .Include(c=> c.Students)
            .FirstOrDefaultAsync(b=> b.Id ==id);
        
        return course;
    }

    public async Task<Course> Create(CreateCourseDto course)
    {
        var newCourse = new Course()
        {
            Name = course.Name,
            Rating = course.Rating,
            Summary = course.Summary,
            TeacherId = course.TeacherId,
        };
        
        
        _dataContext.Courses.Add(newCourse);
        await _dataContext.SaveChangesAsync();

        return newCourse;
    }

    public async Task<Course?> Update(int id, UpdateCourseDto course)
    {
        var dbCourse = await FindOne(id);

        if (dbCourse is null)
        {
            throw new NotFoundException();
        }
        
        _dataContext.Entry(dbCourse).CurrentValues.SetValues(course);
        
        await _dataContext.SaveChangesAsync();
        return dbCourse;
    }
    
    public async Task<bool> Delete(int id)
    {
        var dbCourse = await FindOne(id);
        
        if (dbCourse is null)
        {
            throw new NotFoundException();
        }
        
        _dataContext.Remove(dbCourse);
        return await _dataContext.SaveChangesAsync() > 0;
    }

}