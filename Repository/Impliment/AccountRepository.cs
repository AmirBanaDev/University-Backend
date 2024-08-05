using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using University_Project.Data;
using University_Project.DTO.Admin;
using University_Project.DTO.User;
using University_Project.Model;
using University_Project.Repository.Interface;
using University_Project.Utility.Mapper;

namespace University_Project.Repository.Impliment
{
    public class AccountRepository : IAccountRepository
    {
        readonly AppDbContext _context;
        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManager;
        readonly RoleManager<Role> _roleManager;
        readonly IHttpContextAccessor _httpContextAccessor;
        public AccountRepository(AppDbContext context, UserManager<User> userManager,
            SignInManager<User> signInManager, RoleManager<Role> roleManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<SignUpResultDto> SignUp(SignUpDto dto)
        {
            SignUpResultDto result = new SignUpResultDto();
            result.SignUpAdminDto = dto;
            IdentityResult? resultIdentity = await _userManager.CreateAsync(dto.SignupDtoToUser(addPassword: false), dto.Password);
            if (!resultIdentity.Succeeded)
            {
                //Console.WriteLine("cant sign up the user");
                result.IsSucced = false;

                return result = new SignUpResultDto
                {
                    IsSucced = false,
                    Errors = resultIdentity.Errors.Select(e => e.Description)
                };
            }
            User? user = await _userManager.FindByNameAsync(dto.UserName);
            if (user == null)
            {
                //Console.WriteLine("can't find the user after sign up");
                return result = new SignUpResultDto
                {
                    IsSucced = false,
                    Errors = ["can't find the user after sign up"]
                };
            }
            string roleName = dto.Role;
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                //Console.WriteLine("can't find the role " + roleName);
                return result = new SignUpResultDto
                {
                    IsSucced = false,
                    Errors = ["can't find the role " + roleName]
                };
            }
            IdentityResult roleResult = await _userManager.AddToRoleAsync(user, roleName);
            if (!roleResult.Succeeded)
            {
                //Console.WriteLine("Can't assign the role to user");
                return result = new SignUpResultDto
                {
                    IsSucced = false,
                    Errors = roleResult.Errors.Select(e => e.Description)
                };
            }
            return result = new SignUpResultDto
            {
                IsSucced = true
            };

        }
        public async Task<bool> Login(SignInDto dto, bool shouldAdmin)
        {
            User? user = await _userManager.Users.FirstOrDefaultAsync(u => dto.PhoneNumber == u.PhoneNumber);
            if (user == null)
            {
                Console.WriteLine("No current user");
                return false;
            }
            bool admin = await _userManager.IsInRoleAsync(user, "admin");
            if (shouldAdmin && admin == false)
            {
                Console.WriteLine("not admin");
                return false;
            }
            SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);
            if (signInResult.Succeeded)
            {
                return true;
            }
            return false;
        }
        public async Task Logout() => await _signInManager.SignOutAsync();
        public async Task<int?> GetLoggedinUser()
             => (await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User))?.Id;
    }
}
