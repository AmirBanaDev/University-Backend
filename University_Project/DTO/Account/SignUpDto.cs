namespace University_Project.DTO.User
{
    public class SignUpDto
    {
        public string DisplayName {  get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string IdCard { get; set; }
        public string Password { get; set; }
        public string? Position { get; set; }
        public int? DepartmentId { get; set; }
        public string Role { get; set; }
    }
}
