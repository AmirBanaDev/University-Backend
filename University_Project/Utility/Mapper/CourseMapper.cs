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
                SessionHour = course.SessionHour,
                SessionMinute = course.SessionMinute,
                IsFinished = course.IsFinished,
            };
        }
        public static Course CreateDtoToCourse(this CreateCourseDto dto)
        {
            return new Course
            {
                Name = dto.Name,
                TypeId = dto.TypeId,
                Banner = dto.Banner,
                Description = dto.Description,
                DepartmentId = dto.DepartmentId,
                Teacher = dto.Teacher,
                NeedSignup = dto.NeedSignup,
                StartDate = dto.StartDate,
                Schedule = dto.Schedule,
                NumberOfSessions = dto.NumberOfSessions,
                Location = dto.Location,
                SessionHour = dto.SessionHour,
                SessionMinute = dto.SessionMinute,
                IsFinished = false
            };
        }
        public static Course UpdateDtoToCourse(this UpdateCourseDto dto, Course item)
        {
            item.Name = dto.Name;
            item.TypeId = dto.TypeId;
            item.Banner = dto.Banner;
            item.Description = dto.Description;
            item.Teacher = dto.Teacher;
            item.NeedSignup = dto.NeedSignup;
            item.StartDate = dto.StartDate;
            item.Schedule = dto.Schedule;
            item.NumberOfSessions = dto.NumberOfSessions;
            item.Location = dto.Location;
            item.SessionHour = dto.SessionHour;
            item.SessionMinute = dto.SessionMinute;
            item.IsFinished = false;
            return item;
        }
    }
}
