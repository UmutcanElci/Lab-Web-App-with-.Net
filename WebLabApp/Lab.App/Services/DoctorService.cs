using AutoMapper;
using Lab.App.Interfaces;
using Lab.Domain.DTOs.Requests;
using Lab.Domain.DTOs.Responses;
using Lab.Domain.Entities;
using Lab.Infrasturcture.Repositories.Interfaces;

namespace Lab.App.Services;

public class DoctorService : IDoctorService
{
    private readonly IMapper _mapper;
    private readonly IDoctorRepository _repository;
    private readonly IPasswordHasher _passwordHasher;

    public DoctorService(IMapper mapper, IDoctorRepository repository, IPasswordHasher passwordHasher)
    {
        _mapper = mapper;
        _repository = repository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Guid> RegisterDoctor(DoctorRegisterRequest request)
    {
        if (!request.Email.EndsWith("@doctor.com"))
        {
            throw new Exception("Email must end with '@doctor.com'");
        }

        var existingDoctor = await _repository.GetEmailAsync(request.Email);
        if (existingDoctor != null)
        {
            throw new Exception("Doctor with this email already exists");
        }

        // Map request to Doctor entity
        var doctor = _mapper.Map<Doctor>(request);
        doctor.Id = Guid.NewGuid();
        doctor.Password = _passwordHasher.HashPassword(request.Password);

        var result = await _repository.AddAsync(doctor);

        return doctor.Id;
    }

    public async Task<GetDoctorResponse.DoctorResponse> GetDoctorById(Guid id)
    {
        var doctor = await _repository.GetByIdAsync(id);
        if (doctor == null)
        {
            throw new Exception("Doctor not found");
        }

        // Map entity to response
        var response = _mapper.Map<GetDoctorResponse.DoctorResponse>(doctor);
        return response;
    }
}