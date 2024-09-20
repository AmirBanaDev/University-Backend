using University_Project.DTO.Course;
using University_Project.Model;

namespace University_Project.Utility.Mapper
{
    public static class CourseMapper
    {
        public static GetCourseDto CourseToGetDto(this Course course)
        {
            return new GetCourseDto
            {
                Id = course.Id,
                Name = course.Name,
                Type = course.Type.Name,
                Banner = course.Banner,
                Description = course.Description,
                Deparment = course.Department.Name,
                teacher = course.Teacher,
                needSignup = course.NeedSignup,
                StartDate = course.StartDate,
                Schedule = course.Schedule,
                NumberOfSessions = course.NumberOfSessions,
                Location = course.Location,
                SessionTime = course.SessionTime,
                IsFinished = course.IsFinished,
                ContentDtos = course.Contents?.Select(e=>e.ContentToGetDto()).ToList(),
            };
        }
        public static Course CreateDtoToCourse(this CreateCourseDto dto)
        {
            return new Course
            {
                Name = dto.Name,
                TypeId = dto.TypeId,
                Description = dto.Description,
                DepartmentId = dto.DepartmentId,
                Teacher = dto.Teacher,
                NeedSignup = dto.NeedSignup,
                StartDate = dto.StartDate,
                Schedule = dto.Schedule,
                NumberOfSessions = dto.NumberOfSessions,
                Location = dto.Location,
                SessionTime = dto.SessionTime,
                IsFinished = false
            };
        }
        public static Course UpdateDtoToCourse(this UpdateCourseDto dto, Course item)
        {
            item.Name = dto.Name;
            item.TypeId = dto.TypeId;
            item.Description = dto.Description;
            item.Teacher = dto.Teacher;
            item.NeedSignup = dto.NeedSignup;
            item.StartDate = dto.StartDate;
            item.Schedule = dto.Schedule;
            item.NumberOfSessions = dto.NumberOfSessions;
            item.Location = dto.Location;
            item.SessionTime = dto.SessionTime;
            item.IsFinished = false;
            return item;
        }
        public static GetFavoriteCourseDto CourseToGetFavorite(this Course item)
        {
            return new GetFavoriteCourseDto
            {
                Id = item.Id,
                Name = item.Name,
                StartDate = item.StartDate,
                IsFinished = item.IsFinished,
            };
        }
        public static GetSignedUpCourseDto CourseToSignedupDto(this Course item)
        {
            return new GetSignedUpCourseDto
            {
                Id = item.Id,
                Name = item.Name,
                StartDate = item.StartDate,
                IsFinished = item.IsFinished
            };
        }
    }
}
