using University_Project.DTO.CourseType;
using University_Project.Model;

namespace University_Project.Repository.Interface
{
    public interface ICourseTypeRepository
    {
        Task<List<CourseType>> GetAll();
        Task<CourseType?> GetById(int id);
        Task<CourseType> Create(CourseTypeDto courseType);
        Task<CourseType?> Update(int id, CourseTypeDto courseType);
        Task<bool> DeleteById(int id);
    }
}
