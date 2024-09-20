namespace University_Project.DTO.Course
{
    public class GetFavoriteCourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public bool IsFinished {  get; set; }
        public string State {  get; set; }
    }
}
