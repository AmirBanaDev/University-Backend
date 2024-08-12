using University_Project.Model;
using University_Project.DTO.Admin;
using University_Project.DTO.User;

namespace University_Project.Repository.Interface
{
    public interface IAccountRepository
    {
        Task<bool> Login(SignInDto dto);
        Task<SignUpResultDto> SignUp(SignUpDto dto);
        Task Logout();
        Task<int?> GetLoggedinUser();
    }
}