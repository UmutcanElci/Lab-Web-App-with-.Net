using System.Xml.Linq;
using AutoMapper;
using Lab.Domain.DTOs.Requests;
using Lab.Domain.DTOs.Responses;
using Lab.Domain.Entities;

namespace Lab.App.Profiles;

public class ReportProfile : Profile
{
    public ReportProfile()
    {
        var rand = new Random();
        
        CreateMap<Report, GetReportResponse>()
            .ForMember(dest => dest.PatientDiagnosis,
                src => src.MapFrom(
                    x => $"Diagnosis : {x.PatientDiagnosis}"))
            .ForMember(dest => dest.ReportDate,
                src => src.MapFrom(
                    x => x.ReportDate.ToString("yyyy-MM-dd HH:mm:ss")));

        CreateMap<CreateReportRequest, Report>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.ReportDate,
                opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.ReportNumber,
                opt => opt.MapFrom(_ => rand.Next(1000000, 9999999)));
    }
}