using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Modules.Exams.Dtos;

public class CreateExamDto
{
    public int ExamNumber { get; set; }
    public int TeacherId { get; set; }      
    public int CourseId { get; set; }
}