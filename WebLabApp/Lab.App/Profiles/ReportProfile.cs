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
                opt => opt.MapFrom(
                    x => $"Diagnosis : {x.PatientDiagnosis}"))
            .ForMember(dest => dest.ReportDate,
                opt => opt.MapFrom(
                    x => x.ReportDate.ToString("yyyy-MM-dd")));

        CreateMap<CreateReportRequest, Report>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.ReportDate,
                opt => opt.MapFrom(_ => DateTime.Now))
            .ForMember(dest => dest.PatientPhoneNumber,
                opt => opt.MapFrom(src => src.PatientPhoneNumber));
        
        CreateMap<UpdateReportRequest, Report>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Id should not be updated
            .ForMember(dest => dest.ReportDate, opt => opt.Ignore()); 

    }
}