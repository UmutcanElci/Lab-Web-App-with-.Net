using Lab.Domain.Entities;
using Lab.Infrasturcture.Data;
using Lab.Infrasturcture.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab.Infrasturcture.Repositories.Implementations;

public class ReportRepository : IReportRepository
{
    private readonly LabAppDbContext _context;

    public ReportRepository(LabAppDbContext context)
    {
        _context = context;
    }

    public async Task<Report> CreateAsync(Report report)
    {
        await _context.Reports.AddAsync(report);
        await _context.SaveChangesAsync();
        return report;
    }

    public async Task UpdateAsync(Report report)
    {
        _context.Reports.Update(report);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var report = await GetByIdAsync(id);

        _context.Reports.Remove(report);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Report> GetByIdAsync(Guid id)
    {
        return (await _context.Reports.FindAsync(id))!;
    }

    public async Task<IEnumerable<Report>> GetAllAsync()
    {
        return await _context.Reports.ToListAsync();
    }

    public async Task<bool> ReportNumberExistsAsync(int reportNumber)
    {
        return await _context.Reports.AnyAsync(r => r.ReportNumber == reportNumber);
    }

}