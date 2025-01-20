using AutoMapper;
using Lab.App.Interfaces;
using Lab.Domain.DTOs.Requests;
using Lab.Domain.DTOs.Responses;
using Lab.Domain.Entities;
using Lab.Infrasturcture.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Lab.App.Services;

public class DoctorService : IDoctorService
{
    private readonly IMapper _mapper;
    private readonly IDoctorRepository _repository;
    private readonly IPasswordHasher<Doctor> _passwordHasher;

    public DoctorService(IMapper mapper, IDoctorRepository repository, IPasswordHasher<Doctor> passwordHasher)
    {
        _mapper = mapper;
        _repository = repository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Doctor> RegisterDoctorAsync(DoctorRegisterRequest request)
    {
        if (!request.Email.EndsWith("@doctor.com"))
        {
            throw new Exception("Email must end with '@doctor.com'");
        }

        var existingDoctor = await _repository.GetEmailAsync(request.Email);
        if (existingDoctor != null)
        {
            throw new Exception("A doctor with this email already exists.");
        }

        // Map request to Doctor entity
        var doctor = _mapper.Map<Doctor>(request);
        doctor.Id = Guid.NewGuid();
        doctor.Password = _passwordHasher.HashPassword(doctor, request.Password);

        // Add doctor to repository
        var result = await _repository.AddAsync(doctor);
        return result;
    }

    public async Task<DoctorLoginRequest?> AuthenticateDoctorAsync(string? email, string password)
    {
        var doctor = await _repository.GetEmailAsync(email);
        if (doctor == null)
        {
            throw new Exception("Doctor not found.");
        }

        var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(doctor, doctor.Password, password);
        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            throw new Exception("Invalid credentials.");
        }

        // Map to response object
        return _mapper.Map<DoctorLoginRequest>(doctor);
    }
}