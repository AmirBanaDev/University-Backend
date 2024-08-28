namespace University_Project.DTO.Course
{
    public class GetCourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type {  get; set; }
        public string? Banner {  get; set; }
        public string? Description { get; set; }
        public string Deparment {  get; set; }
        public string? teacher {  get; set; }
        public bool needSignup {  get; set; }
        public DateTime StartDate { get; set; }
        public string? Schedule { get; set; }
        public int NumberOfSessions { get; set; }
        public string Location { get; set; }
        public int SessionHour { get; set; }
        public int SessionMinute { get; set; }
        public bool IsFinished { get; set; } = false;
    }
}
