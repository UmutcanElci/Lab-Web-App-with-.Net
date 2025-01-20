namespace Lab.Domain.DTOs.Responses;

public class GetDoctorResponse
{
    public class DoctorResponse
    {
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string? Specialization { get; set; }
        public string LabName { get; set; }
    }
}