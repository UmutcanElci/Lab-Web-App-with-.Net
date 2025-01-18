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

    public testController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReportRequest request)
    {
        var id = await _reportService.Create(request);

        return Ok();
    }

    [HttpGet]
    public async Task<IEnumerable<GetReportResponse>> GetAll()
    {
        return await _reportService.GetAllReports();
    }
}