using System.ComponentModel.DataAnnotations;

namespace Lab.Domain.DTOs.Requests;

public class CreateReportRequest
{
    [Required]
    public string PatientName { get; set; }
    [Required]
    public string PatientSurname { get; set; }
    [EmailAddress]
    public string? PatientEmail { get; set; }
    public string? PatientAddress { get; set; }
    [Phone]
    public string? PatientPhoneNumber { get; set; }
    public string? ReportPicture { get; set; }
}