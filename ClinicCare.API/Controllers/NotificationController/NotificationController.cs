using Microsoft.AspNetCore.Mvc;
using ClinicCare.BLL.Services.NotificationService;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims; 

namespace ClinicCare.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize] 
public class NotificationController : ControllerBase
{
    private readonly INotificationService _service;

    public NotificationController(INotificationService service)
    {
        _service = service;
    }


    [HttpGet("my")]
    public async Task<IActionResult> GetMyNotifications()
    {
        
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return Unauthorized("User not found.");

        var result = await _service.GetUserNotificationsAsync(Guid.Parse(userId));
        return Ok(result);
    }


    [HttpPatch("read/{id}")]
    public async Task<IActionResult> MarkAsRead(Guid id)
    {
        var response = await _service.MarkAsReadAsync(id);
        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

  
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _service.DeleteNotificationAsync(id);
        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }
}