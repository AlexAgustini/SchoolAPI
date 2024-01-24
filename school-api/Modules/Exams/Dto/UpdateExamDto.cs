using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Modules.Exams.Dtos;

public class UpdateExamDto
{
    public int ExamNumber { get; set; }
    
    public int TeacherId { get; set; }      
    
    public int CourseId { get; set; }
}