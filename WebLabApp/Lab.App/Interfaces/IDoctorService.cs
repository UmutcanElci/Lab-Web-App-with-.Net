using Lab.Domain.DTOs.Requests;
using Lab.Domain.Entities;

namespace Lab.App.Interfaces;

public interface IDoctorService
{
    Task<Doctor> RegisterDoctorAsync(DoctorRegisterRequest request);
    Task<DoctorLoginRequest?> AuthenticateDoctorAsync(string? email, string password);
    
}