namespace SchoolAPI.Modules.Exams.Models;

public class Exam
{
    public int Id { get; set; }
    public int ExamNumber { get; set; }
    public int TeacherId { get; set; }      
    public int CourseId { get; set; }
}