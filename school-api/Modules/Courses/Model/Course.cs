using SchoolAPI.Modules.Students.Models;

namespace SchoolAPI.Modules.Courses.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Summary { get; set; }
    public int Rating { get; set; }
    public int? TeacherId { get; set; }

    public List<Student> Students { get; }  = [];

}