using AutoMapper;
using Lab.Domain.DTOs.Requests;
using Lab.Domain.DTOs.Responses;
using Lab.Domain.Entities;

namespace Lab.App.Profiles;

public class DoctorProfile : Profile
{
    public DoctorProfile()
    {
        CreateMap<DoctorRegisterRequest, Doctor>();
        CreateMap<Doctor, DoctorDignosisResponse>();

    }
}