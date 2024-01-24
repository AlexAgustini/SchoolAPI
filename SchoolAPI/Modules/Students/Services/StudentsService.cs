using SchoolAPI.Modules.Students.Dtos;
using SchoolAPI.Modules.Students.Repositories;
using SchoolAPI.Modules.Students.Models;

namespace SchoolAPI.Modules.Students.Services;

public class StudentsService
{
    private readonly StudentsRepository _studentsRepository;
    
    public StudentsService(StudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }
    
    public async Task<List<Student>> FindAll()
    {
        return await _studentsRepository.FindAll();
    } 
    public async Task<Student> FindOne(int id)
    {
        return await _studentsRepository.FindOne(id);
    } 
    public async Task<Student> Create(UpdateStudentDto updateStudent)
    {
        return await _studentsRepository.Create(updateStudent);
    }

    public async Task<Student> AddCourse(int studentId, int courseId)
    {
        return await _studentsRepository.AddCourse(studentId, courseId);
    }
    public async Task<Student> Update(int id, UpdateStudentDto updateStudent)
    {
        return await _studentsRepository.Update(id, updateStudent);
    } 
    public async Task<bool> Delete(int id)
    {
        return await _studentsRepository.Delete(id);
    }
}