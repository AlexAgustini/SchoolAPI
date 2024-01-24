using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Modules.Auth.Attributes;
using SchoolAPI.Modules.Core.Exceptions;
using SchoolAPI.Modules.Exams.Dtos;
using SchoolAPI.Modules.Exams.Models;
using SchoolAPI.Modules.Exams.Services;
using SchoolAPI.Modules.Users.Enums;

namespace SchoolAPI.Modules.Exams.Controllers;

[Route("exams")]
[ApiController]
public class ExamsController : ControllerBase
{

    private readonly ExamsService _examsService;

    public ExamsController(ExamsService examsService)
    {
        _examsService = examsService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Exam>>> FindAll()
    {
        return await _examsService.FindAll();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Exam>> FindOne(int id)
    {
        var exam = await _examsService.FindOne(id);

        if (exam is null)
        {
            throw new NotFoundException();
        }

        return exam;
    }

    [HttpPost]
    public async Task<ActionResult<Exam>> Insert(CreateExamDto exam)
    {
        var createdExam = await _examsService.Create(exam);
        return CreatedAtAction(nameof(Insert), new { id = createdExam.Id }, createdExam);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Exam>> Update(int id, UpdateExamDto exam)
    {
        var updatedExam = await _examsService.Update(id, exam);
        return Ok(updatedExam);
    }

    [AuthorizeRoles(UserRoleEnum.Admin)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _examsService.Delete(id);
        return NoContent();
    }
}

