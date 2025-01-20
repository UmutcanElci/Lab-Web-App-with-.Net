namespace Lab.Domain.DTOs.Responses;

public class DoctorDignosisResponse
{
    public Guid ReportId { get; set; }
    public string PatientName { get; set; }
    public string PatientSurname { get; set; }
    public string Diagnosis { get; set; }
    public string DiagnosisDetail { get; set; }
    public DateTime ReportDate { get; set; }
    public string? ReportPicture { get; set; }
    public string DoctorName { get; set; }
    public string DoctorSurname { get; set; }
}