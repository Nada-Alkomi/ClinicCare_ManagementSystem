using Clinic.Care.DAL.QueryHandler;
using Microsoft.AspNetCore.Mvc;
using ClinicCare.BLL.Services.MedicalRecordService; 
using ClinicCare.BLL.Dtos.MedicalRecordDto; 
using Microsoft.AspNetCore.Authorization;

namespace ClinicCare.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicalRecordController : ControllerBase
{
    private readonly IMedicalRecordService _service;

    public MedicalRecordController(IMedicalRecordService service)
    {
        _service = service;
    }

    [Authorize(Roles = "Admin,Doctor")]
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
       
        var result = await _service.GetAllMedicalRecordsAsync(new Query
        {
            pageNumber = 1,
            pagesize = 100
        });

        return Ok(result);
    }
    
    [Authorize(Roles = "Admin,Doctor,Patient")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetMedicalRecordByIdAsync(id);
        if (result == null)
            return NotFound("Medical record not found.");

        return Ok(result);
    }

    [Authorize(Roles = "Admin,Doctor")]
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateMedicalRecordDto dto)
    {
        var response = await _service.AddMedicalRecordAsync(dto);
        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [Authorize(Roles = "Admin,Doctor")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMedicalRecordDto dto)
    {
       
        var response = await _service.UpdateMedicalRecordAsync(id, dto);
        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [Authorize(Roles = "Admin,Doctor")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
       
        var response = await _service.DeleteMedicalRecordAsync(id);
        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
}