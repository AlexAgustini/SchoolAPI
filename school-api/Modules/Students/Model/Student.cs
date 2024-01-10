using System.ComponentModel.DataAnnotations;
using SchoolAPI.Modules.Courses.Models;

namespace SchoolAPI.Modules.Students.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string Email { get; set; }
    public int Age { get; set; }

    public List<Course> Courses { get; } = [];


}