using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;  
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Extensions;
using SchoolAPI.Modules.Auth.Dtos;
using SchoolAPI.Modules.Core.Exceptions;
using SchoolAPI.Modules.Users.Dtos;
using SchoolAPI.Modules.Users.Extensions;
using SchoolAPI.Modules.Users.Models;
using SchoolAPI.Modules.Users.Repositories;

namespace SchoolAPI.Modules.Auth.Services;

public class AuthenticationService
{
    private readonly UsersRepository _usersRepository;
    private readonly IConfiguration _configuration;

    public AuthenticationService(UsersRepository usersRepository, IConfiguration configuration)
    {
        _usersRepository = usersRepository;
        _configuration = configuration;
    }


    public async Task<UserTokenResult> Login(LoginDto login)
    {
        var user = await _usersRepository.FindOneByEmail(login.Email);

        
        if (user is null || !BCrypt.Net.BCrypt.Verify(login.Password, user.Hash))
        {
            throw new UnauthorizedException();
        }

        var token = GenerateToken(user);

        return new UserTokenResult(user.ToUserDto(), token);
    }
    
    private string GenerateToken(User user)
    {

        var userRole = user.Role.GetDisplayName();
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JwtSecret")!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, userRole),
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

public record UserTokenResult(UserDto User, string Token);


