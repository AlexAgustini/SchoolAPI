using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Modules.Users.Dtos;

public class ChangePasswordDto
{
    
    [DataType(DataType.Password)]
    [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
    [Required]
    public string Password { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = null!;
}