using University_Project.DTO.Course;
using University_Project.Model;

namespace University_Project.Repository.Interface
{
    public interface ICourseRepository
    {
        public Task<List<GetCourseDto>> GetAll();
        public Task<GetCourseDto?> GetById(int id);
        public Task<GetCourseDto?> GetByDepartment(int id);
        public Task<GetCourseDto?> Create(CreateCourseDto course);
        public Task<GetCourseDto?> Update(int id, UpdateCourseDto course);
        public Task<bool> DeleteById(int id);
        public Task<bool> FinishCourse(int id);
    }
}
