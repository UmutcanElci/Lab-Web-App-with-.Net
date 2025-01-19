namespace Lab.Domain.Entities;

public class Report
{
    public Guid Id { get; set; }
    public int ReportNumber { get; set; }
    public string? PatientName { get; set; }
    public string? PatientSurname { get; set; }
    public string? PatientEmail { get; set; }
    public string? PatientAddress { get; set; }
    public string? PatientPhoneNumber { get; set; }
    public int PatientNumber { get; set; }
    public string? PatientDiagnosis { get; set; }
    public string? DiagnosisDetail { get; set; }
    public DateTime ReportDate { get; set; }
    public string? ReportPicture { get; set; }
}