using System.ComponentModel;

namespace University_Project.DTO.User
{
    public class GetUserResultDto
    {
        public int Id { get; set; }
        public string DisplayName {  get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber {  get; set; }
        public string IdCard {  get; set; }
        public string Position {  get; set; }
        public string? Department {  get; set; }
        public string? BirthDate {  get; set; }
        public string? ProfilePicture {  get; set; }
        public int CourseAttendent {  get; set; }

    }
}
