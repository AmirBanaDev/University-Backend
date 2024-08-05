namespace University_Project.DTO.User
{
    public class SignUpResultDto
    {
        public bool IsSucced { get; set; }
        public IEnumerable<string?> Errors { get; set; }
        public SignUpDto SignUpAdminDto { get; set; }
    }
}
