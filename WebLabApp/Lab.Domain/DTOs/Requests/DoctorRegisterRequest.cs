using System.ComponentModel.DataAnnotations;

namespace Lab.Domain.DTOs.Requests;

public class DoctorRegisterRequest
{
    [Required]
    [EmailAddress]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@doctor\.com$", ErrorMessage = "Email must end with '@doctor.com'")]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    [Required]
    public string? DoctorName { get; set; }

    [Required]
    public string? DoctorSurname { get; set; }

    public string? Specialization { get; set; }
}