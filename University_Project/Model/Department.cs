using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace University_Project.Model
{
    public class Department
    {
        public int Id { get; set; }
        [AllowNull]
        public ICollection<User> Members { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
