using System.ComponentModel.DataAnnotations;
using SchoolAPI.Modules.Courses.Models;

namespace SchoolAPI.Modules.Students.Dtos;

public class CreateStudentDto
{
    public string Name { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    public int Age { get; set; }

    public List<Course>? Courses = new List<Course>();
}