using University_Project.DTO.User;
using University_Project.Model;

namespace University_Project.Repository.Interface
{
    public interface IUserRepository
    {
        Task<GetUserResultDto?> GetById(int id);
        Task<GetUserFavoAndCoursesDto?> GetFavoAndSignups(int id);
        Task<List<GetUserResultDto>> GetAll();
        Task<List<Role>> GetRoles();
        Task<User?> Update(int id, UpdateUserByAdminDto newUserDto);
        Task<bool> Delete(int id);
        Task<bool> AddFavoriteCourse(int id, int cid);
        Task<bool> AddSignupCourse(int id, int cid);
        Task<bool> RemoveFavoriteCourse(int id, int cid);
    }
}
