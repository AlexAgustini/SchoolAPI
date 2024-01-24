using SchoolAPI.Modules.Teachers.Dto;
using SchoolAPI.Modules.Teachers.Models;
using SchoolAPI.Modules.Teachers.Repositories;

namespace SchoolAPI.Modules.Teachers.Services;
public class TeachersService
{

    private readonly TeachersRepository _teachersRepository;
    
    public TeachersService(TeachersRepository teachersRepository)
    {
        _teachersRepository = teachersRepository;
    }
    
    public async Task<List<Teacher>> FindAll()
    {
        return await _teachersRepository.FindAll();
    } 
    public async Task<Teacher?> FindOne(int id)
    {
        return await _teachersRepository.FindOne(id);
    } 
    public async Task<Teacher> Create(CreateTeacherDto createTeacher)
    {
        return await _teachersRepository.Create(createTeacher);
    } 
    public async Task<Teacher> Update(int id, CreateTeacherDto createTeacher)
    {
        return await _teachersRepository.Update(id, createTeacher);
    } 
    public async Task<Teacher> Delete(int id)
    {
        return await _teachersRepository.Delete(id);
    }
}