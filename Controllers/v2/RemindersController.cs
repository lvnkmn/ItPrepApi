using Microsoft.AspNetCore.Mvc;
namespace ItPrepApi.Controllers.v2;
using Asp.Versioning;
using ItPrepApi.Controllers.v2.Dtos;

[ApiController]
[ApiVersion(2)]
[Route("v{version:apiVersion}/reminders")]
public class RemindersController: ControllerBase {
    private IReminderService _reminderService;

    public RemindersController(IReminderService reminderService) {
        _reminderService = reminderService;
    }

    [HttpGet("GetAllReminders", Name = "GetAllReminders")]
    public async Task<IEnumerable<Reminder>> GetAllAsync()
    {
        var reminders = await _reminderService.GetAllAsync();
        return reminders.ToArray();
    }

    [HttpGet("GetReminder", Name = "GetReminder")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var reminder = await _reminderService.GetByIdAsync(id);
        if (reminder is null)
        {
            return NotFound();
        }
        return Ok(reminder);
    }

    [HttpPost("AddNewReminder", Name = "AddNewReminder")]
    public async Task<IActionResult> AddAsync(CreateReminderRequest request){
        var reminder = new Reminder
        {
            Id = 0,
            Description = request.Description,
            DueDate = request.DueDate
        };

        await _reminderService.AddAsync(reminder);
        return Ok();
    }

    [HttpDelete("DeleteReminder", Name = "DeleteReminder")]
    public async Task<IActionResult> DeleteAsync(int id){
        if(await _reminderService.DeleteAsync(id)) {
            return Ok();
        }
        return NoContent();
    }

    [HttpPut("UpdateReminder", Name = "UpdateReminder")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateReminderRequest request){
        var reminder = new Reminder
        {
            Id = 0,
            Description = request.Description,
            DueDate = request.DueDate
        };
        if(await _reminderService.UpdateAsync(id, reminder)) {
            return Ok();
        }
        return NoContent();
    }
}