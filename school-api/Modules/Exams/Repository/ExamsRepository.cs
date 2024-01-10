using Microsoft.EntityFrameworkCore;
using SchoolAPI.Modules.Core.Database;
using SchoolAPI.Modules.Core.Exceptions;
using SchoolAPI.Modules.Exams.Dtos;
using SchoolAPI.Modules.Exams.Models;

namespace SchoolAPI.Modules.Exams.Repositories;

public class ExamsRepository
{
    private readonly DataContext _dataContext;
    
    public ExamsRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<Exam>> FindAll()
    {
        var exams = await _dataContext.Exams.ToListAsync();
        return exams;
    }

    public async Task<Exam> FindOne(int id)
    {
        var exams = await _dataContext.Exams
            .FirstOrDefaultAsync(b=> b.Id ==id);
        if (exams is null)
        {
            throw new NotFoundException();
        }
        return exams;
    }

    public async Task<Exam> Create(CreateExamDto createExam)
    {
        var newExam = new Exam()
        {
            ExamNumber = createExam.ExamNumber,
            TeacherId = createExam.TeacherId,
            CourseId = createExam.CourseId
        };
        
        
        _dataContext.Exams.Add(newExam);
        await _dataContext.SaveChangesAsync();

        return newExam;
    }

    public async Task<Exam> Update(int id, UpdateExamDto createExam)
    {
        var dbExam = await FindOne(id);
        
            _dataContext.Entry(dbExam).CurrentValues.SetValues(createExam);
        
        await _dataContext.SaveChangesAsync();
        return dbExam;
    }
    
    public async Task<bool> Delete(int id)
    {
        var dbExam = await FindOne(id);
        _dataContext.Remove(dbExam);
        return await _dataContext.SaveChangesAsync() > 0;
    }

}