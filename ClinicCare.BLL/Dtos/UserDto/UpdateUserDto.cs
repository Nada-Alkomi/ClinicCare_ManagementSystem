using System.ComponentModel.DataAnnotations;

namespace ClinicCare.BLL.Dtos.UserDto;

public class UpdateUserDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public string Gender { get; set; } = string.Empty;

    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    public string? ProfilePictureUrl { get; set; }
}