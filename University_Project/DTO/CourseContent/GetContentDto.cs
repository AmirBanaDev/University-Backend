using System.Diagnostics.CodeAnalysis;

namespace University_Project.DTO.CourseContent
{
    public class GetContentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Files { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
