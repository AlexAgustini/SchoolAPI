using SchoolAPI.Modules.Courses.Models;
using SchoolAPI.Modules.Exams.Models;

namespace SchoolAPI.Modules.Teachers.Models;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public ICollection<Course> Courses { get; } = [];

    public IEnumerable<Exam> Exams { get; } = [];

}