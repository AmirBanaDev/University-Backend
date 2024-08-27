namespace University_Project.DTO.Course
{
    public class CreateCourseDto
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string? Banner { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public string? Teacher { get; set; }
        public bool NeedSignup { get; set; } = false;
        public DateTime StartDate { get; set; }
        public string? Schedule {  get; set; }
        public int NumberOfSessions { get; set; }
        public string Location { get; set; }
        public int SessionHour { get; set; }
        public int SessionMinute { get; set; }
    }
}
