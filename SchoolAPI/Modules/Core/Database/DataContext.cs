using Microsoft.EntityFrameworkCore;
using SchoolAPI.Modules.Courses.Models;
using SchoolAPI.Modules.Exams.Models;
using SchoolAPI.Modules.Students.Models;
using SchoolAPI.Modules.Teachers.Models;
using SchoolAPI.Modules.Users.Models;

namespace SchoolAPI.Modules.Core.Database;

public class DataContext : DbContext
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<User> Users { get; set; }

    public DataContext(DbContextOptions options) : base(options)
    {
        
    }    
}