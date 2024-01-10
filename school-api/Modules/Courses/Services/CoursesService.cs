using SchoolAPI.Modules.Courses.Dtos;
using SchoolAPI.Modules.Courses.Models;
using SchoolAPI.Modules.Courses.Repositories;

namespace SchoolAPI.Modules.Courses.Services;

public class CoursesService
{

    private readonly CoursesRepository _coursesRepository;
    
    public CoursesService(CoursesRepository coursesRepository)
    {
        _coursesRepository = coursesRepository;
    }
    
    public async Task<List<Course>> FindAll()
    {
        return await _coursesRepository.FindAll();
    } 
    public async Task<Course> FindOne(int id)
    {
        return await _coursesRepository.FindOne(id);
    } 
    public async Task<Course> Create(CreateCourseDto course)
    {
        return await _coursesRepository.Create(course);
    } 
    public async Task<Course> Update(int id, UpdateCourseDto course)
    {
        return await _coursesRepository.Update(id, course); 
    } 
    public async Task<bool> Delete(int id)
    {
        return await _coursesRepository.Delete(id);
    }
}