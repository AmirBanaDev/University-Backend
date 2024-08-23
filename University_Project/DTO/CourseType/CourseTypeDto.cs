using System.ComponentModel.DataAnnotations;

namespace University_Project.DTO.CourseType
{
    public class CourseTypeDto
    {
        [Required(ErrorMessage = "اسم نباید خالی باشد")]
        public string Name {  get; set; }
    }
}
