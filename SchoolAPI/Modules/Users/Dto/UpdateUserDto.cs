using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SchoolAPI.Common.Attributes;
using SchoolAPI.Modules.Users.Enums;

namespace SchoolAPI.Modules.Users.Dtos;

public class UpdateUserDto
{
    public string Name { get; set; }
        
    [EmailAddress]
    public string Email { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    [ValidEnum]
    public UserRoleEnum Role { get; set; }
}