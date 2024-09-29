using System.ComponentModel;

namespace University_Project.DTO.User
{
    public class UpdateUserDto
    {
        public string? Birthdate { get; set; }
        public IFormFile? ProfilePicture { get; set; }  
        public string? Email {  get; set; }
    }
}
