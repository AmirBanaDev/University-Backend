using System.Diagnostics.CodeAnalysis;
using University_Project.DTO.CourseContent;

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
        public DateOnly StartDate { get; set; }
        public string? Schedule { get; set; }
        public int NumberOfSessions { get; set; }
        public string Location { get; set; }
        public int SessionTime { get; set; }
        [AllowNull]
        public List<GetContentDto> ContentDtos { get; set; }
        public bool IsFinished { get; set; } = false;
    }
}
