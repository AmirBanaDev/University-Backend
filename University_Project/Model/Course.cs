using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace University_Project.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId {  get; set; }
        public CourseType Type { get; set; }
        public string? Banner {  get; set; }
        public string? Description {  get; set; }
        public int DepartmentId {  get; set; }
        public Department Department { get; set; }
        //add departments
        public string? Teacher {  get; set; }
        public bool NeedSignup { get; set; } = false;
        public DateOnly StartDate { get; set; }
        public string? Schedule { get; set; }
        public int NumberOfSessions {  get; set; }
        public string Location {  get; set; }
        public int SessionTime {  get; set; }
        public bool IsFinished {  get; set; } = false;

        [AllowNull]
        public List<RollCall> RollCallList { get; set; }
        [AllowNull]
        public List<CourseContent> Contents { get; set; }
    }
}
