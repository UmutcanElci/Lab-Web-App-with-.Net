using System.ComponentModel.DataAnnotations;

namespace Lab.Domain.DTOs.Requests;

public class DoctorDiagnosisRequest
{
    [Required]
    public Guid ReportId { get; set; }

    [Required]
    public string Diagnosis { get; set; }

    [Required]
    public string DiagnosisDetail { get; set; }

    public DateTime? ReportDate { get; set; }
    public string? ReportPicture { get; set; }
}