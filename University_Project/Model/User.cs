using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_Project.Model
{
    public class User:IdentityUser<int>
    {
        public string DisplayName {  get; set; }
        public string IdCard {  get; set; }
        public string? Position {  get; set; }
        public int? DepartmentId {  get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
        public string? Birthdate {  get; set; }
        public string? ProfilePicture {  get; set; }
        [DefaultValue(0)]
        public int CourseAttendent { get; set; }
        public List<UserCourseFavorite> Favorite { get; set; }
        [ForeignKey("Favorite")]
        public List<Course> Favorites { get; set; }
        public List<UserCourseSignup> Signup { get; set; }
        [ForeignKey("Signup")]
        public List<Course> Signups { get; set; }
    }
}
