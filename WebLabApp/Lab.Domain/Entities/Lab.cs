namespace Lab.Domain.Entities;

public class Lab
{
    public Guid Id { get; set; }
    public string? LabName { get; set; }
    
    public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    public ICollection<Report> Reports { get; set; } = new List<Report>();
}