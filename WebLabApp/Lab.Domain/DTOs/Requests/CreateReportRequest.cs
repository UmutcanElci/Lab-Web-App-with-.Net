namespace Lab.Domain.DTOs.Requests;

public class CreateReportRequest
{
    public string? PatientName { get; set; }
    public string? PatientSurname { get; set; }
    public string? ReportPicture { get; set; }
}