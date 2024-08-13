using University_Project.Model;
using University_Project.DTO.Admin;
using University_Project.DTO.User;
using University_Project.DTO.Account;

namespace University_Project.Repository.Interface
{
    public interface IAccountRepository
    {
        Task<SignInResultDto> Login(SignInDto dto);
        Task<SignUpResultDto> SignUp(SignUpDto dto);
        Task Logout();
        Task<int?> GetLoggedinUser();
    }
}