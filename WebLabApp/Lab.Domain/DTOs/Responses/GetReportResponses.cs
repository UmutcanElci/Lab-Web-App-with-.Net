namespace Lab.Domain.DTOs.Responses;

public class GetReportResponses
{
    public int ReportNumber { get; set; }
    public string? PatientName { get; set; }
    public string? PatientSurname { get; set; }
    public int PatientNumber { get; set; }
    public string? PatientDiagnosis { get; set; }
    public string? DiagnosisDetail { get; set; }
    public DateTime ReportDate { get; set; }
    public string? ReportPicture { get; set; }
}