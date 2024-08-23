using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace University_Project.Model
{
    [Index(nameof(Name), IsUnique = true)]
    public class CourseType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [AllowNull]
        public List<Course>? Courses { get; set; }
    }
}
