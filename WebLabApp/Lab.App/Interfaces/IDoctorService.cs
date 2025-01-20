using Lab.Domain.DTOs.Requests;
using Lab.Domain.Entities;

namespace Lab.App.Interfaces;

public interface IDoctorService
{
    Task RegisterDoctorAsync(DoctorRegisterRequest request);
    Task<Doctor?> AuthenticateDoctorAsync(string email, string password);
    
}