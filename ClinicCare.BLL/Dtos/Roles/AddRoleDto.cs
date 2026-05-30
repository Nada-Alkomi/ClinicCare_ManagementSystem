using System.ComponentModel.DataAnnotations;

namespace ClinicCare.BLL.Dtos.Roles;

public class AddRoleDto
{
[Required]
[MaxLength(50,ErrorMessage ="Role name must be less than 50 characters")]
    public string RoleName { get; set; }=string.Empty;
    
}