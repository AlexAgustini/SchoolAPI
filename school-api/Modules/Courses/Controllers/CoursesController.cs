using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Modules.Courses.Dtos;
using SchoolAPI.Modules.Courses.Models;
using SchoolAPI.Modules.Courses.Services;

namespace SchoolAPI.Modules.Courses.Controllers;

[Authorize]
[Route("courses")]
[ApiController]
public class CoursesController : ControllerBase
{

    private readonly CoursesService _coursesService;

    public CoursesController(CoursesService coursesService)
    {
        _coursesService = coursesService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Course>>> FindAll()
    {
        return await _coursesService.FindAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Course>> FindOne(int id)
    {
        return await _coursesService.FindOne(id);
    }

    [HttpPost]
    public async Task<ActionResult<Course>> Insert(CreateCourseDto course)
    {
        var createdCourse = await _coursesService.Create(course);
        return CreatedAtAction(nameof(Insert), new { id = createdCourse.Id }, createdCourse);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Course>> Update(int id, UpdateCourseDto course)
    {
        var updatedCourse = await _coursesService.Update(id, course);
        return Ok(updatedCourse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _coursesService.Delete(id);
        return NoContent();
    }
}