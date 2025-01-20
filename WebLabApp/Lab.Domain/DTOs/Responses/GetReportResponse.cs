namespace Lab.Domain.DTOs.Responses;

public class GetReportResponse
{
    public string ReportNumber { get; set; }
    public DateTime ReportDate { get; set; }
    public string PatientName { get; set; }
    public string PatientSurname { get; set; }
    public string? PatientEmail { get; set; }
    public string? PatientAddress { get; set; }
    public string? PatientPhoneNumber { get; set; }
    public string? ReportPicture { get; set; }
    public string? PatientDiagnosis { get; set; }
    public string? DiagnosisDetail { get; set; }
}