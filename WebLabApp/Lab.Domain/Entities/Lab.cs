﻿namespace Lab.Domain.Entities;

public class Lab
{
    public Guid Id { get; set; }
    public string? DoctorName { get; set; }
    public string? DoctorSurname { get; set; }
    public int DoctorId { get; set; }
    public int ReportId { get; set; }
}