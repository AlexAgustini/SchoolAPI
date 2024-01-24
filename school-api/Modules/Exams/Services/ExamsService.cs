using SchoolAPI.Modules.Core.Exceptions;
using SchoolAPI.Modules.Courses.Services;
using SchoolAPI.Modules.Exams.Dtos;
using SchoolAPI.Modules.Exams.Models;
using SchoolAPI.Modules.Exams.Repositories;
using SchoolAPI.Modules.Teachers.Services;

namespace SchoolAPI.Modules.Exams.Services;

public class ExamsService
{

    private readonly TeachersService _teachersService;
    private readonly CoursesService _coursesService;

    private readonly ExamsRepository _examsRepository;
    
    public ExamsService(ExamsRepository examsRepository, TeachersService teachersService, CoursesService coursesService)
    {
        _examsRepository = examsRepository;
        _teachersService = teachersService;
        _coursesService = coursesService;
    }
    
    public async Task<List<Exam>> FindAll()
    {
        return await _examsRepository.FindAll();
    } 
    public async Task<Exam?> FindOne(int id)
    {
        return await _examsRepository.FindOne(id);
    } 
    public async Task<Exam> Create(CreateExamDto exam)
    {
        
        var teacher = await _teachersService.FindOne(exam.TeacherId);
        var course = await _coursesService.FindOne(exam.CourseId);

        if (teacher is null)
        {
            throw new NotFoundException(message: "Teacher not found");
        }
        if (course is null)
        {
            throw new NotFoundException(message: "Course not found");
        }
        
        return await _examsRepository.Create(exam);
    } 
    public async Task<Exam?> Update(int id, UpdateExamDto exam)
    {
        return await _examsRepository.Update(id, exam); 
    } 
    public async Task<bool> Delete(int id)
    {
        return await _examsRepository.Delete(id);
    }
}