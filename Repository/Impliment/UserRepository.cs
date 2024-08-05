using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using University_Project.Data;
using University_Project.DTO.User;
using University_Project.Model;
using University_Project.Repository.Interface;
using University_Project.Utility.Mapper;
using System.Linq;

namespace University_Project.Repository.Impliment
{
    public class UserRepository : IUserRepository
    {
        readonly AppDbContext _context;
        readonly UserManager<User> _userManager;
        public UserRepository(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<GetUserResultDto?> GetById(string id)
        {
            User? user = await _userManager.FindByIdAsync(id);
            return user?.UserToGetUserResultDto();
        }
        public async Task<List<GetUserResultDto>> GetAll()
        {
            List<GetUserResultDto> users = await _context.users
                .Select(user => user.UserToGetUserResultDto()).ToListAsync();
            return users;
        }
        public async Task<User?> Update(int id, UpdateUserByAdminDto newUserDto)
        {
            User user = await _userManager.FindByIdAsync(id.ToString());
            User newUser = newUserDto.UpdateUserByAdminDtoToUser(user);
            IdentityResult? userResult = await _userManager.UpdateAsync(newUser);
            if(!userResult.Succeeded) return null;
            return user;
        }
        public async Task<bool> Delete(int id)
        {
            User user = await _userManager.FindByIdAsync(id.ToString());
            IdentityResult deleteResult = await _userManager.DeleteAsync(user);
            if(!deleteResult.Succeeded) return false;
            return true;
        }
    }
}
