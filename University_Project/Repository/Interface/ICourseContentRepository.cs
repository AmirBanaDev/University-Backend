using University_Project.DTO.CourseContent;

namespace University_Project.Repository.Interface
{
    public interface ICourseContentRepository
    {
        public Task<List<GetContentDto>?> GetByCourse(int courseId);
        public Task<GetContentDto> Create(int courseId, SendContentDto dto);
        public Task<GetContentDto?> Update(int id, UpdateContentDto dto);
        public Task<bool> Delete(int id);
    }
}
