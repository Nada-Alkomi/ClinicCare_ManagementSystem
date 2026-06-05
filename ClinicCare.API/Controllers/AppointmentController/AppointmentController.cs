using Microsoft.AspNetCore.Mvc;
using ClinicCare.BLL.Services.AppointmentService;
using ClinicCare.BLL.Dtos.AppointmentDtos;
using Microsoft.AspNetCore.Authorization;
using Clinic.Care.DAL.QueryHandler; 

namespace ClinicCare.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _service;

    public AppointmentController(IAppointmentService service)
    {
        _service = service;
    }

    [Authorize(Roles = "Admin,Doctor")]
    [HttpGet("all")]
    public async Task<IActionResult> GetAll([FromQuery] Query query)
    {
        var result = await _service.GetAllAppointmentsAsync(); 
        return Ok(result);
    }

  
    [Authorize(Roles = "Admin,Patient")]
    [HttpPost("book")]
    public async Task<IActionResult> BookAppointment([FromBody] CreateAppointmentDto dto)
    {
        var response = await _service.BookAppointmentAsync(dto);
        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }


    [Authorize(Roles = "Admin")]
    [HttpPatch("confirm/{id}")]
    public async Task<IActionResult> ConfirmAppointment(Guid id)
    {
        var response = await _service.ConfirmAppointmentAsync(id);
        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [Authorize(Roles = "Admin,Patient")]
    [HttpPatch("cancel/{id}")]
    public async Task<IActionResult> CancelAppointment(Guid id)
    {
        var response = await _service.CancelAppointmentAsync(id);
        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }


    [Authorize(Roles = "Admin,Doctor")]
    [HttpPatch("complete/{id}")]
    public async Task<IActionResult> CompleteAppointment(Guid id)
    {
        var response = await _service.CompleteAppointmentAsync(id);
        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

   
    [Authorize(Roles = "Admin,Doctor,Patient")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var appointment = await _service.GetAppointmentByIdAsync(id);
        return appointment != null ? Ok(appointment) : NotFound("Appointment not found.");
    }
}