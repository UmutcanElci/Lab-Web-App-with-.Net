using AutoMapper;
using Lab.App.Interfaces;
using Lab.Domain.DTOs.Requests;
using Lab.Domain.DTOs.Responses;
using Lab.Domain.Entities;

namespace Lab.App.Services;

public class ReportService : IReportService
{
    private readonly IMapper _mapper;
    private readonly List<Report> _reports = new();

    public ReportService(IMapper mapper)
    {
        _mapper = mapper;
    }
    public Task<Guid> Create(CreateReportRequest reportRequest)
    {
        
        var report = _mapper.Map<Report>(reportRequest);

      
        _reports.Add(report);
        
        return Task.FromResult(report.Id);
    }

    public Task Update(Guid Id, CreateReportRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task GetById(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GetReportResponse>> GetAllReports()
    {
        var reportResponses = _mapper.Map<IEnumerable<GetReportResponse>>(_reports);
        return Task.FromResult(reportResponses);
    }
}