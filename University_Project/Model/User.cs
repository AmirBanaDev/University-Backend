using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace University_Project.Model
{
    public class User:IdentityUser<int>
    {
        public string IdCard {  get; set; }
        public string? Position {  get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId {  get; set; }
        public Department? Department { get; set; }
        public string? Birthdate {  get; set; }
        public string? ProfilePicture {  get; set; }
        [DefaultValue(0)]
        public int CourseAttendent { get; set; }
    }
}
