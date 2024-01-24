using System.ComponentModel.DataAnnotations.Schema;
using SchoolAPI.Modules.Exams.Models;
using SchoolAPI.Modules.Students.Models;
using SchoolAPI.Modules.Teachers.Models;

namespace SchoolAPI.Modules.Courses.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Summary { get; set; }
    public int Rating { get; set; }
    public int? TeacherId { get; set; }
    
    
    public Teacher? Teacher { get; set; }

    public ICollection<Student> Students { get; }  = [];
    public ICollection<Exam> Exams { get; }  = [];
    

}