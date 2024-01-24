using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Modules.Auth.Dtos;
using SchoolAPI.Modules.Auth.Services;

namespace SchoolAPI.Modules.Auth.Controllers;

[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly AuthenticationService _authService;

    public AuthController(AuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<UserTokenResult>> Login(LoginDto login)
    {
        return await _authService.Login(login);
    }
    
    
    
}



