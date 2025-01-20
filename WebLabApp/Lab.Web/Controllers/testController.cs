using AutoMapper;
using Lab.App.Interfaces;
using Lab.Domain.DTOs.Requests;
using Lab.Domain.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Web.Controllers;
[ApiController]
[Route("api/[controller]")]
public class testController : ControllerBase
{
    
    private readonly IReportService _reportService;
    private readonly IMapper _mapper;
    public testController(IReportService reportService, IMapper mapper)
    {
        _reportService = reportService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReportRequest request)
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

    [HttpGet]
    public async Task<IEnumerable<GetReportResponse>> GetAll()
    {
        return await _reportService.GetAllReports();
    }
}