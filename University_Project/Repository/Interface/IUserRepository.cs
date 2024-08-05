using University_Project.DTO.User;
using University_Project.Model;

namespace University_Project.Repository.Interface
{
    public interface IUserRepository
    {
        Task<GetUserResultDto?> GetById(string id);
        Task<List<GetUserResultDto>> GetAll();
        Task<User?> Update(int id, UpdateUserByAdminDto newUserDto);
        Task<bool> Delete(int id);
    }
}
