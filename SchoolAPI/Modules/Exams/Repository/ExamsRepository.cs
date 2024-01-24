using Microsoft.EntityFrameworkCore;
using SchoolAPI.Modules.Core.Database;
using SchoolAPI.Modules.Core.Exceptions;
using SchoolAPI.Modules.Exams.Dtos;
using SchoolAPI.Modules.Exams.Models;

namespace SchoolAPI.Modules.Exams.Repositories;

public class ExamsRepository(
    DataContext dataContext
    )
{
    public async Task<List<Exam>> FindAll()
    {
        var exams = await dataContext.Exams
            .Include((e=> e.Course))
            .Include((e=> e.Teacher))
            .ToListAsync();
        return exams;
    }

    public async Task<Exam?> FindOne(int id)
    {
        var exam = await dataContext.Exams
            .Include((e=> e.Course))
            .Include((e=> e.Teacher))
            .FirstOrDefaultAsync(b=> b.Id ==id);
        
        return exam;
    }

    public async Task<Exam> Create(CreateExamDto createExam)
    {
        var newExam = new Exam()
        {
            ExamNumber = createExam.ExamNumber,
            TeacherId = createExam.TeacherId,
            CourseId = createExam.CourseId
        };

        
        
        dataContext.Exams.Add(newExam);
        await dataContext.SaveChangesAsync();

        return newExam;
    }

    public async Task<Exam?> Update(int id, UpdateExamDto createExam)
    {
        var dbExam = await FindOne(id);

        if (dbExam is null)
        {
            throw new NotFoundException();
        }

        dataContext.Entry(dbExam).CurrentValues.SetValues(createExam);
        
        await dataContext.SaveChangesAsync();
        return dbExam;
    }
    
    public async Task<bool> Delete(int id)
    {
        var dbExam = await FindOne(id);
        
        if (dbExam is null)
        {
            throw new NotFoundException();
        }
        dataContext.Remove(dbExam);
        return await dataContext.SaveChangesAsync() > 0;
    }

}