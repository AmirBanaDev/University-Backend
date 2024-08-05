namespace University_Project.DTO.Account
{
    public class UpdateAccountDto
    {
        public string UserName {  get; set; }
        public string PhoneNumber {  get; set; }
        public string IdCard { get; set; }
        public string? Position { get; set; }
        public int? DepartmentId { get; set; }
        public string Role {  get; set; }
    }
}
