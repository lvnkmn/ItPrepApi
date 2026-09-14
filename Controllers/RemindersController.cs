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
        this._reminderService = reminderService;
        this._reminderService.Add(
            new Reminder
            {
                Id = 1,
                Description = "Buy milk",
                DueDate = DateTime.Now.AddDays(1)
            }
        );
    }

    [HttpGet("GetAllReminders", Name = "GetAllReminders")]
    public IEnumerable<Reminder> GetAll()
    {
        var reminders = _reminderService.GetAll();
        return reminders.ToArray();
    }

    [HttpPost("AddNewReminder", Name = "AddNewReminder")]
    public IActionResult Add(Reminder reminder){
        _reminderService.Add(reminder);
        return Ok();
    }

    [HttpDelete("DeleteReminder", Name = "DeleteReminder")]
    public IActionResult Add(int id){
        if(_reminderService.Delete(id)) {
            return Ok();
        }
        return NoContent();
    }
}
