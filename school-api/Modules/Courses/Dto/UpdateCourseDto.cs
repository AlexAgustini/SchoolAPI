using SchoolAPI.Modules.Students.Models;

namespace SchoolAPI.Modules.Courses.Dtos;

public class UpdateCourseDto
{
    public string Name { get; set; }
    public string Summary { get; set; }
    public int Rating { get; set; }
    public int? TeacherId { get; set; }
    public List<Student>? Students = new List<Student>();
}