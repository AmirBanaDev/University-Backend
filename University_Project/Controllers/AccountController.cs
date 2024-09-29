using Microsoft.AspNetCore.Mvc;
using University_Project.Model;
using University_Project.DTO.Admin;
using University_Project.Repository.Interface;
using University_Project.DTO.User;
using Microsoft.AspNetCore.Authorization;
using University_Project.DTO.Account;

namespace University_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepo;
        public AccountController(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignupByAdmin([FromBody] SignUpDto dto)
        {
            SignUpResultDto? result = await _accountRepo.SignUp(dto);
            return result.IsSucced ? Accepted(result.SignUpAdminDto)
                : BadRequest(result.Errors);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInDto dto)
        {
            SignInResultDto user = await _accountRepo.Login(dto);
            return user != null ? Ok(user) : BadRequest("No login accepted");
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepo.Logout();
            return Ok("Logged out");
        }
    }

}
