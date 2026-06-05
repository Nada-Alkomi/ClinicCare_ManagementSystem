using ClinicCare.DAL.Models;

namespace ClinicCare.BLL.Dtos.UserDto;

public class GetUserByIdDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }

    public string Gender { get; set; } = string.Empty;

    public string? ProfilePictureUrl { get; set; }

    public UserRole Role { get; set; }
}