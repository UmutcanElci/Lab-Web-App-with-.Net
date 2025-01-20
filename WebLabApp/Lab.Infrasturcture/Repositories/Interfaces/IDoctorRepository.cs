using Lab.Domain.Entities;

namespace Lab.Infrasturcture.Repositories.Interfaces;

public interface IDoctorRepository
{
    Task<Doctor> GetEmailAsync(string? email);
    Task<Doctor> AddAsync(Doctor doctor);
    Task<Doctor> GetByIdAsync(Doctor doctor);
}