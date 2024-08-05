using System.ComponentModel.DataAnnotations;

namespace University_Project.DTO.Admin
{
    public class SignInDto
    {
        [Required(ErrorMessage ="فیلد نباید خالی باشد")]
        [RegularExpression("^[0-9]*$",ErrorMessage ="فقط عدد وارد کنید")]
        public string PhoneNumber {  get; set; }
        [Required(ErrorMessage = "فیلد نباید خالی باشد")]
        public string Password { get; set; }
    }
}
