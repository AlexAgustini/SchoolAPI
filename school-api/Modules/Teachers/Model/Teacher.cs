using SchoolAPI.Modules.Courses.Models;

namespace SchoolAPI.Modules.Teachers.Models;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public int Age { get; set; }

    public List<Course>? Courses = new List<Course>();
    
}