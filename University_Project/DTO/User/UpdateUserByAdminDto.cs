using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace University_Project.DTO.User
{
    public class UpdateUserByAdminDto
    {
        public string DisplayName {  get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string IdCard { get; set; }
        public string? Position { get; set; }
        public int? DepartmentId { get; set; }
    }
}
