
using Microsoft.AspNetCore.Authorization;
using SchoolAPI.Modules.Users.Enums;

namespace SchoolAPI.Modules.Auth.Attributes;

public class AuthorizeRolesAttribute : AuthorizeAttribute
{
    public AuthorizeRolesAttribute(params UserRoleEnum[] allowedRoles)
    {
        var allowedRolesAsStrings = allowedRoles.Select(x => Enum.GetName(typeof(UserRoleEnum), x));
        Roles = string.Join(",", allowedRolesAsStrings);
    }
}