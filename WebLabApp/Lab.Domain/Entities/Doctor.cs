namespace Lab.Domain.Entities;

public class Doctor
{
    public Guid Id { get; set; }
    public string? DoctorName { get; set; }
    public string? DoctorSurname { get; set; }
    public string? Specialization { get; set; } 
    public Guid? LabId { get; set; }
    public Lab? Lab { get; set; }
    
    public string? Email { get; set; }
    public string? Password { get; set; }
    
    public ICollection<Report>? Reports { get; set; } = new List<Report>();
}