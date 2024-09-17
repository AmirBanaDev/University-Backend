using System.Diagnostics.CodeAnalysis;

namespace University_Project.DTO.CourseContent
{
    public class SendContentDto
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        [AllowNull]
        public List<IFormFile> File { get; set; }
    }
}
