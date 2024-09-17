using System.Diagnostics.CodeAnalysis;

namespace University_Project.Model
{
    public class CourseContent
    {
        public int Id { get; set; }
        public int CourseId {  get; set; }
        public Course Course { get; set; }
        public string Title {  get; set; }
        public string? Description { get; set; }
        [AllowNull]
        public List<string> File {  get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
