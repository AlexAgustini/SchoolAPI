using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;  
using Microsoft.IdentityModel.Tokens;
using school;
using SchoolAPI.Modules.Auth.Dtos;
using SchoolAPI.Modules.Users.Dtos;
using SchoolAPI.Modules.Users.Extensions;
using SchoolAPI.Modules.Users.Repositories;

namespace SchoolAPI.Modules.Auth.Services;

public class AuthenticationService
{
    private readonly UsersRepository _usersRepository;

    public AuthenticationService(UsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }


    public async Task<UserTokenResult> Login(LoginDto login)
    {
        var user = await _usersRepository.FindOneByEmail(login.Email);

        
        if (user is null || !BCrypt.Net.BCrypt.Verify(login.Password, user.Hash))
        {
            throw new UnauthorizedException();
        }

        var token = GenerateToken();

        return new UserTokenResult(user.ToUserDto(), token);
    }
    
    private static string GenerateToken()
    {

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("djasiodjiosajdsiodjisodjsoijdasodjoadjdodoaidj");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, "Admin", ""),
                new Claim(ClaimTypes.Role, "AdminMaster"),
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

public record UserTokenResult(UserDto User, string Token);
