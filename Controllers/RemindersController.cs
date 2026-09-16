using ItPrepApi;
using Microsoft.AspNetCore.Mvc;
namespace ItPrepApi.Controllers;

/*
Add Controllers/ItemsController.cs. Inherit from ControllerBase, decorate the class with [ApiController] and [Route("[controller]")] (this maps the class name minus "Controller" to the route, i.e. items).
Add a constructor taking IItemService (the interface, not the concrete class) and store it in a private readonly field — same constructor-injection pattern as Program.cs registering the service.
[HttpGet] → call GetAll(), wrap the result in Ok(...).
[HttpGet("{id}")] → call GetById(id); if the result is null return NotFound(), otherwise Ok(item).
[HttpPost] → accept the item from the request body as a parameter, call Add(...), return CreatedAtAction (or Ok) with the created item.
[HttpPut("{id}")] → call Update(id, item); return NoContent() if it returned true, NotFound() if false.
[HttpDelete("{id}")] → same pattern as Update, calling Delete(id).
*/

[ApiController]
[Route("[controller]")]
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
    public async Task<IActionResult> AddAsync(Reminder reminder){
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
    public async Task<IActionResult> UpdateAsync(int id, Reminder reminder){
        if(await _reminderService.UpdateAsync(id, reminder)) {
            return Ok();
        }
        return NoContent();
    }
}
