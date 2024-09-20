using System.Diagnostics.CodeAnalysis;

namespace University_Project.DTO.CourseContent
{
    public class SendContentDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public IFormFile? File { get; set; }
    }
}
