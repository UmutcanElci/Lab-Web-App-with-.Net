using AutoMapper;
using Lab.App.Interfaces;
using Lab.Domain.DTOs.Requests;
using Lab.Domain.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IReportService _reportService;
    private readonly IDoctorService _doctorService;
    private readonly IMapper _mapper;

    public TestController(IReportService reportService, IDoctorService doctorService, IMapper mapper)
    {
        _reportService = reportService;
        _doctorService = doctorService;
        _mapper = mapper;
    }

    // Report endpoints

    [HttpPost("report/create")]
    public async Task<IActionResult> CreateReport([FromBody] CreateReportRequest request)
    {
        try
        {
            var id = await _reportService.Create(request);
            return Ok(new { id });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpPut("report/update/{id:guid}")]
    public async Task<IActionResult> UpdateReport(Guid id, [FromBody] CreateReportRequest request)
    {
        try
        {
            await _reportService.Update(id, request);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpDelete("report/delete/{id:guid}")]
    public async Task<IActionResult> DeleteReport(Guid id)
    {
        try
        {
            var deleted = await _reportService.Delete(id);
            return Ok(new { deleted });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet("report/{id:guid}")]
    public async Task<IActionResult> GetReportById(Guid id)
    {
        try
        {
            var report = await _reportService.GetById(id);
            if (report == null)
                return NotFound();

            return Ok(report);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet("report")]
    public async Task<IActionResult> GetAllReports()
    {
        try
        {
            var reports = await _reportService.GetAllReports();
            return Ok(reports);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    // Doctor endpoints

    [HttpPost("doctor/register")]
    public async Task<IActionResult> RegisterDoctor([FromBody] DoctorRegisterRequest request)
    {
        try
        {
            var id = await _doctorService.RegisterDoctorAsync(request);
            return Ok(new { id });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpPost("doctor/login")]
    public async Task<IActionResult> AuthenticateDoctor([FromBody] DoctorLoginRequest request)
    {
        try
        {
            var response = await _doctorService.AuthenticateDoctorAsync(request.Email, request.Password);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(401, new { message = ex.Message });
        }
    }
    
    
}
