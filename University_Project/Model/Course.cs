namespace University_Project.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId {  get; set; }
        public CourseType Type { get; set; }
        public string? Banner {  get; set; }
        public int UserId {  get; set; }
        public User Creator {  get; set; }
        //add departments
        public string? Teacher {  get; set; }
        public bool NeedSignup { get; set; } = false;
        public DateTime StartDate { get; set; }
        public int NumberOfSessions {  get; set; }
        public string Location {  get; set; }
        public float SessionLength {  get; set; }
        public bool IsFinished {  get; set; } = false;
        public List<RollCall> RollCallList { get; set; }
        //add users attendent
    }
}
