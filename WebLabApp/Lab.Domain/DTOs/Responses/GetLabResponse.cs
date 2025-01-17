namespace Lab.Domain.DTOs.Responses;

public class GetLabResponse
{
    public string? DoctorName { get; set; }
    public string? DoctorSurname { get; set; }
    public int ReportId { get; set; }
}