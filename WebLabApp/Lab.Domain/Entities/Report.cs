namespace Lab.Domain.Entities;

public class Report
{
    public Guid Id { get; set; }
    public int ReportNumber { get; set; }
    public string PatientName { get; set; }
    public string PatientSurname { get; set; }
    public string? PatientMail { get; set; }
    public string? PatientAddress { get; set; }
    public long? PatientPhoneNumber { get; set; }
    public string? PatientDiagnosis { get; set; }
    public string? DiagnosisDetail { get; set; }
    public DateTime ReportDate { get; set; }
    public string? ReportPicture { get; set; }
    
    public Guid LabId { get; set; }
    public Lab Lab { get; set; }

    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
}