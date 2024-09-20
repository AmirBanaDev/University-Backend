namespace University_Project.DTO.Course
{
    public class CreateCourseDto
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public IFormFile? Banner { get; set; }
        public string? Description { get; set; }
        public int DepartmentId { get; set; }
        public string? Teacher { get; set; }
        public bool NeedSignup { get; set; } = false;
        public DateOnly StartDate { get; set; }
        public string? Schedule {  get; set; }
        public int NumberOfSessions { get; set; }
        public string Location { get; set; }
        public int SessionTime {  get; set; }
    }
}
