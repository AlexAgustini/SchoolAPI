using System.ComponentModel.DataAnnotations;
using SchoolAPI.Modules.Courses.Models;

namespace SchoolAPI.Modules.Teachers.Dto;

public class CreateTeacherDto
{
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public int Age { get; set; }

    public List<Course> Courses = new List<Course>();
}