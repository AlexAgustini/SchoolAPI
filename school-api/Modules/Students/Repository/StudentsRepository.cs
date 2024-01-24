using Microsoft.EntityFrameworkCore;
using SchoolAPI.Modules.Students.Dtos;
using SchoolAPI.Modules.Students.Models;
using SchoolAPI.Modules.Core.Database;
using SchoolAPI.Modules.Core.Exceptions;
using SchoolAPI.Modules.Courses.Models;
using SchoolAPI.Modules.Courses.Repositories;

namespace SchoolAPI.Modules.Students.Repositories;

public class StudentsRepository 
{
    private readonly DataContext _dataContext;

    private readonly CoursesRepository _coursesRepository;

    public StudentsRepository(DataContext dataContext, CoursesRepository coursesRepository)
    {
        _dataContext = dataContext;
        _coursesRepository = coursesRepository;
    }

    public async Task<List<Student>> FindAll()
    {
        var students = await _dataContext.Students
            .Include(s=> s.Courses)
            .ToListAsync();
        return students;
    }

    public async Task<Student> FindOne(int id)
    {
        var student = await _dataContext.Students
            .Include(s=> s.Courses)
            .FirstOrDefaultAsync(a => a.Id == id);
        if (student is null)
        {
            throw new NotFoundException();
        }

        return student;
    }

    public async Task<Student> Create(UpdateStudentDto updateStudent)
    {
        var newStudent = new Student()
        {
            Name = updateStudent.Name,
            Email = updateStudent.Email,
            Age = updateStudent.Age,
        };


        _dataContext.Students.Add(newStudent);
        await _dataContext.SaveChangesAsync();

        return newStudent;
    }
    
    public async Task<Student> AddCourse(int studentId, int courseId)
    {
        var student = await FindOne(studentId);
        var course = await _coursesRepository.FindOne(courseId);

        student.Courses.Add(course);

        await _dataContext.SaveChangesAsync();

        return student;
    }

    public async Task<Student> Update(int id, UpdateStudentDto updateStudent)
    {
        var dbStudent = await FindOne(id);

        _dataContext.Entry(dbStudent).CurrentValues.SetValues(updateStudent);

        await _dataContext.SaveChangesAsync();
        return dbStudent;
    }

    public async Task<bool> Delete(int id)
    {
        var student = await FindOne(id);
        _dataContext.Remove(student);
        return await _dataContext.SaveChangesAsync() > 0;
    }
}