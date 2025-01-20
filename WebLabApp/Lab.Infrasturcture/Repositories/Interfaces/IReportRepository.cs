using Lab.Domain.Entities;

namespace Lab.Infrasturcture.Repositories.Interfaces;

public interface IReportRepository
{
    Task<Report> CreateAsync(Report report);
    Task UpdateAsync(Report report);
    Task<bool> DeleteAsync(Guid id);
    Task<Report> GetByIdAsync(Guid id);
    Task<IEnumerable<Report>> GetAllAsync();
    Task<bool> ReportNumberExistsAsync(int reportNumber);

}