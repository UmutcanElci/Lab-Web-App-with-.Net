using AutoMapper;
using Lab.App.Interfaces;
using Lab.Domain.DTOs.Requests;
using Lab.Domain.DTOs.Responses;
using Lab.Domain.Entities;
using Lab.Infrasturcture.Repositories.Interfaces;

namespace Lab.App.Services;

public class ReportService : IReportService
{
    private readonly IMapper _mapper;
    private readonly IReportRepository _repository;

    public ReportService(IMapper mapper, IReportRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<Guid> Create(CreateReportRequest reportRequest)
    {
        
        var report = _mapper.Map<Report>(reportRequest);


        var result = await _repository.CreateAsync(report);

        return result.Id;
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

    public async Task<IEnumerable<GetReportResponse>> GetAllReports()
    {
        var report = await _repository.GetAllAsync();
        var reportResponses = _mapper.Map<IEnumerable<GetReportResponse>>(report);
        return reportResponses.ToList();
    }
}