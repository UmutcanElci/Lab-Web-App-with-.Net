using Lab.Domain.Entities;
using Lab.Infrasturcture.Data;
using Lab.Infrasturcture.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab.Infrasturcture.Repositories.Implementations;

public class DoctorRepository : IDoctorRepository
{
    private readonly LabAppDbContext _context;

    public DoctorRepository(LabAppDbContext context)
    {
        _context = context;
    }

    public async Task<Doctor> GetEmailAsync(string email)
    {
        return await _context.Doctors.FirstOrDefaultAsync(d => d.Email == email);
    }

    public async Task AddAsync(Doctor doctor)
    {
        await _context.Doctors.AddAsync(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task<Doctor?> GetByIdAsync(Guid Id)
    {
        return await _context.Doctors.FindAsync(Id);
    }
}