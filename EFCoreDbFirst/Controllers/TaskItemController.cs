using EFCoreDbFirst.Context;
using EFCoreDbFirst.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDbFirst.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskItemController : ControllerBase
{
    private readonly ILogger<TaskItemController> _logger;
    private readonly TaskDbContext _context;

    public TaskItemController(ILogger<TaskItemController> logger, TaskDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<TaskItem>> Insert(string title, string description)
    {
        var task = new TaskItem(title, description);

        _context.Add(task);
        await _context.SaveChangesAsync();

        return Ok(task);
    }

    [HttpGet]
    [Route("all")]
    public async Task<ActionResult<List<TaskItem>>> List() => Ok(await _context.TaskItem.ToListAsync());

    [HttpGet]
    [Route("inactives")]
    public async Task<ActionResult<List<TaskItem>>> ListInactives() => Ok(await _context.TaskItem.Where(t => t.Active == false).ToListAsync());

    [HttpGet]
    [Route("actives")]
    public async Task<ActionResult<List<TaskItem>>> ListActives() => Ok(await _context.TaskItem.Where(t => t.Active == true).ToListAsync());

    [HttpGet]
    [Route("get")]
    public async Task<ActionResult<List<TaskItem>>> Get(int id) => Ok(await _context.TaskItem.FindAsync(id));

    [HttpPut]
    [Route("update")]
    public async Task<ActionResult<TaskItem>> Update(int id, TaskItemDTO updatedTaskItem)
    {
        TaskItem? task = await _context.TaskItem.FindAsync(id);

        if (task == null) return NotFound(id);
        if (string.IsNullOrEmpty(updatedTaskItem.Title) && string.IsNullOrEmpty(updatedTaskItem.Description)) return BadRequest("No Changes Detected");

        if (!string.IsNullOrEmpty(updatedTaskItem.Title))
            task.SetTitle(updatedTaskItem.Title);

        if (!string.IsNullOrEmpty(updatedTaskItem.Description))
            task.SetDescription(updatedTaskItem.Description);

        _context.TaskItem.Update(task);
        await _context.SaveChangesAsync();

        return Ok(task);
    }

    [HttpPatch]
    [Route("inactivate")]
    public async Task<ActionResult<TaskItem>> Inactivate(int id)
    {
        TaskItem? task = await _context.TaskItem.FindAsync(id);

        if (task == null) return NotFound(id);

        task.Inactivate();

        _context.TaskItem.Update(task);
        await _context.SaveChangesAsync();

        return Ok(task);
    }

    [HttpPatch]
    [Route("activate")]
    public async Task<ActionResult<TaskItem>> Activate(int id)
    {
        TaskItem? task = await _context.TaskItem.FindAsync(id);

        if (task == null) return NotFound(id);

        task.Activate();

        _context.TaskItem.Update(task);
        await _context.SaveChangesAsync();

        return Ok(task);
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<ActionResult<int>> Delete(int id)
    {
        TaskItem? task = await _context.TaskItem.FindAsync(id);

        if (task == null) return NotFound(id);

        _context.TaskItem.Remove(task);
        await _context.SaveChangesAsync();

        return Ok(id);
    }
}

