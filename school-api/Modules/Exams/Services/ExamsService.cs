using SchoolAPI.Modules.Exams.Dtos;
using SchoolAPI.Modules.Exams.Models;
using SchoolAPI.Modules.Exams.Repositories;

namespace SchoolAPI.Modules.Exams.Services;

public class ExamsService
{

    private readonly ExamsRepository _examsRepository;
    
    public ExamsService(ExamsRepository examsRepository)
    {
        _examsRepository = examsRepository;
    }
    
    public async Task<List<Exam>> FindAll()
    {
        return await _examsRepository.FindAll();
    } 
    public async Task<Exam> FindOne(int id)
    {
        return await _examsRepository.FindOne(id);
    } 
    public async Task<Exam> Create(CreateExamDto exam)
    {
        return await _examsRepository.Create(exam);
    } 
    public async Task<Exam> Update(int id, UpdateExamDto exam)
    {
        return await _examsRepository.Update(id, exam); 
    } 
    public async Task<bool> Delete(int id)
    {
        return await _examsRepository.Delete(id);
    }
}