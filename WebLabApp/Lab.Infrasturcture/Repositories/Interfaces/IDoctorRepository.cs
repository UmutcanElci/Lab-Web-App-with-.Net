using Lab.Domain.Entities;

namespace Lab.Infrasturcture.Repositories.Interfaces;

public interface IDoctorRepository
{
    Task<Doctor> GetEmailAsync(string email);
    Task AddAsync(Doctor doctor);
    Task<Doctor?> GetByIdAsync(Guid Id);
}