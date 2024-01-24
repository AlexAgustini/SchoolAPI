using System.ComponentModel.DataAnnotations.Schema;
using SchoolAPI.Modules.Courses.Models;
using SchoolAPI.Modules.Teachers.Models;

namespace SchoolAPI.Modules.Exams.Models;

public class Exam
{
    public int Id { get; set; }
    public int ExamNumber { get; set; }
    public int TeacherId { get; set; } 
    public int CourseId { get; set; }
    
    [ForeignKey("TeacherId")]
    public Teacher Teacher { get; set; }
    
    [ForeignKey("CourseId")]
    public Course Course { get; set; }
}