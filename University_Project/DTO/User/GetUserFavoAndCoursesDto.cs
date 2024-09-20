using University_Project.DTO.Course;

namespace University_Project.DTO.User
{
    public class GetUserFavoAndCoursesDto
    {
        public List<GetSignedUpCourseDto>?  Signups { get; set; }
        public List<GetFavoriteCourseDto>?  Favorites { get; set; }
    }
}
