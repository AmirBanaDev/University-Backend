using Microsoft.AspNetCore.Mvc;
using University_Project.Model;
using University_Project.DTO.Admin;
using University_Project.Repository.Interface;
using University_Project.DTO.User;
using Microsoft.AspNetCore.Authorization;

namespace University_Project.Controllers.Admin
{
    [Route("api/admin/[controller]")]
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
            bool isCorrect = await _accountRepo.Login(dto, shouldAdmin: true);
            return isCorrect ? Ok("You Successfully login") : BadRequest("No login accepted");
        }
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _accountRepo.Logout();
            return Ok("Logged out");
        }
    }

}
