using System.ComponentModel.DataAnnotations;

namespace Lab.Domain.DTOs.Requests;

public class CreateReportRequest
{
    [Required]
    public string? PatientName { get; set; }
    [Required]
    public string? PatientSurname { get; set; }
    public string? ReportPicture { get; set; }
    [EmailAddress]
    public string? PatientEmail { get; set; }
    public string? PatientAddress { get; set; }
    public string? PatientPhoneNumber { get; set; }
}