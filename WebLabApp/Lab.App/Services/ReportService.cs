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
        
        var report = _mapper.Map<Report>(reportRequest); // Used <Report> because creating fresh Report object

        // Generate a unique ReportNumber
        report.ReportNumber = await GenerateUniqueReportNumberAsync();

        var result = await _repository.CreateAsync(report);
        return result.Id;
    }

    public async Task Update(Guid Id, CreateReportRequest updateRequest)
    {
        var report = await _repository.GetByIdAsync(Id);
        _mapper.Map(updateRequest, report);

        await _repository.UpdateAsync(report);
    }

    public async Task<bool> Delete(Guid Id)
    {
        var deleted = await _repository.DeleteAsync(Id);
        return deleted;
    }

    public async Task<Report> GetById(Guid Id)
    {
        var report = await _repository.GetByIdAsync(Id);
        
        return report;
    }

    public async Task<IEnumerable<GetReportResponse>> GetAllReports()
    {
        var report = await _repository.GetAllAsync();
        var reportResponses = _mapper.Map<IEnumerable<GetReportResponse>>(report);
        return reportResponses.ToList();
    }
    private async Task<int> GenerateUniqueReportNumberAsync()
    {
        int reportNumber;
        var rand = new Random();

        do
        {
            reportNumber = rand.Next(1000000, 9999999);
        }
        while (await _repository.ReportNumberExistsAsync(reportNumber));

        return reportNumber;
    }

}