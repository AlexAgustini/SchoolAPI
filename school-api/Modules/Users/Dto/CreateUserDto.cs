using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SchoolAPI.Common.Attributes;
using SchoolAPI.Modules.Users.Enums;

namespace SchoolAPI.Modules.Users.Dtos;

public class CreateUserDto
{
    [Required]
    public string Name { get; set; }
    
    [DataType(DataType.Password)]
    [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
    [Required]
    public string Password { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [JsonProperty(Required = Required.Always)]
    [ValidEnum]
    public UserRoleEnum Role { get; set; }
    
    [Required]
    public int? TeacherId { get; set; }
}

