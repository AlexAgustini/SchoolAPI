using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Modules.Teachers.Dto;
using SchoolAPI.Modules.Teachers.Models;
using SchoolAPI.Modules.Teachers.Services;

namespace SchoolAPI.Modules.Teachers.Controllers;

[Authorize]
[Route("teachers")]
[ApiController]
public class TeachersController : ControllerBase
{

    private readonly TeachersService _teachersService;

    public TeachersController(TeachersService teachersService)
    {
        _teachersService = teachersService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Teacher>>> FindAll()
    {
        return await _teachersService.FindAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Teacher>> FindOne(int id)
    {
        return await _teachersService.FindOne(id);
    }

    [HttpPost]
    public async Task<ActionResult<Teacher>> Insert(CreateTeacherDto createTeacher)
    {
        var createdTeacher = await _teachersService.Create(createTeacher);
        return CreatedAtAction(nameof(Insert), new { id = createdTeacher.Id }, createdTeacher);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Teacher>> Update(int id, CreateTeacherDto createTeacher)
    {
        var updatedBook = await _teachersService.Update(id, createTeacher);
        return Ok(updatedBook);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _teachersService.Delete(id);
        return NoContent();
    }
}