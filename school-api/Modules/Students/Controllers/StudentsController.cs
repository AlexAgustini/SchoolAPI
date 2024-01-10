using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Modules.Courses.Dtos;
using SchoolAPI.Modules.Students.Dtos;
using SchoolAPI.Modules.Students.Models;
using SchoolAPI.Modules.Students.Services;

namespace SchoolAPI.Modules.Students.Controllers;

    
[Authorize]
[Route("students")]
[ApiController]
public class StudentsController : ControllerBase
{

    private readonly StudentsService _studentsService;

    public StudentsController(StudentsService studentsService)
    {
        _studentsService = studentsService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Student>>> FindAll()
    {
        return await _studentsService.FindAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> FindOne(int id)
    {
        return await _studentsService.FindOne(id);
    }

    [HttpPost]
    public async Task<ActionResult<Student>> Insert(UpdateStudentDto updateStudent)
    {
        var createdStudent = await _studentsService.Create(updateStudent);
        return CreatedAtAction(nameof(Insert), new { id = createdStudent.Id }, createdStudent);
    }

    [HttpPost("{studentId}/add-course/{courseId}")]

    public async Task<ActionResult<Student>> AddStudentCourse(int studentId, int courseId)
    {
        return await _studentsService.AddCourse(studentId, courseId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Student>> Update(int id, UpdateStudentDto updateStudent)
    {
        var updatedStudent = await _studentsService.Update(id, updateStudent);
        return Ok(updatedStudent);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _studentsService.Delete(id);
        return NoContent();
    }
}