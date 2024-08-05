using System.ComponentModel;

namespace University_Project.DTO.User
{
    public class UpdateUserDto
    {
        public string? Birthdate { get; set; }
        public string? ProfilePicture { get; set; }  
        public string? Email {  get; set; }
    }
}
