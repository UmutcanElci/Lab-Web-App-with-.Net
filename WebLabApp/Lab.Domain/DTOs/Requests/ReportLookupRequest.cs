using System.ComponentModel.DataAnnotations;

namespace Lab.Domain.DTOs.Requests;

public class ReportLookupRequest
{
    [Required]
    public int ReportNumber { get; set; }
}