using Lab.Domain.DTOs.Requests;
using Lab.Domain.DTOs.Responses;
using Lab.Domain.Entities;

namespace Lab.App.Interfaces;
//Need Dto
public interface IReportService
{
    Task<Guid> Create(CreateReportRequest reportRequest);
    Task Update(Guid Id, CreateReportRequest updateRequest);
    Task<bool> Delete(Guid Id);
    Task GetById(Guid Id);
    Task<IEnumerable<GetReportResponse>> GetAllReports();
}