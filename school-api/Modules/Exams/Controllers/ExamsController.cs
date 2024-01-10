using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Modules.Exams.Dtos;
using SchoolAPI.Modules.Exams.Models;
using SchoolAPI.Modules.Exams.Services;

namespace SchoolAPI.Modules.Exams.Controllers;

[Authorize]
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

    [HttpGet("{id}")]
    public async Task<ActionResult<Exam>> FindOne(int id)
    {
        return await _examsService.FindOne(id);
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _examsService.Delete(id);
        return NoContent();
    }
}