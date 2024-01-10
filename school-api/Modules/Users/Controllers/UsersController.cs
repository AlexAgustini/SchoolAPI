using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Modules.Users.Dtos;
using SchoolAPI.Modules.Users.Models;
using SchoolAPI.Modules.Users.Services;

namespace SchoolAPI.Modules.Users.Controllers;

[Authorize]
[Route("users")]
[ApiController]
public class UsersController : ControllerBase
{

    private readonly UsersService _usersService;

    public UsersController(UsersService usersService)
    {
        _usersService = usersService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> FindAll()
    {
        return Ok(await _usersService.FindAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> FindOne(int id)
    {
        return Ok(await _usersService.FindOne(id));
    }

    [HttpPost]
    public async Task<ActionResult<User>> Insert(CreateUserDto user)
    {
        var createdUser = await _usersService.Create(user);
        return CreatedAtAction(nameof(Insert), new { id = createdUser.Id }, createdUser);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<User>> Update(int id, UpdateUserDto user)
    {
        var updatedUser = await _usersService.Update(id, user);
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _usersService.Delete(id);
        return NoContent();
    }
}