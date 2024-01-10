namespace SchoolAPI.Modules.Users.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string Hash { get; set; }
    public string Email { get; set; }
    
    public int? TeacherId { get; set; }
    
}