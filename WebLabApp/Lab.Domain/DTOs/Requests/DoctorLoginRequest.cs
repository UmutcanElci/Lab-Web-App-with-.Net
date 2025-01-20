using System.ComponentModel.DataAnnotations;

namespace Lab.Domain.DTOs.Requests;

public class DoctorLoginRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}