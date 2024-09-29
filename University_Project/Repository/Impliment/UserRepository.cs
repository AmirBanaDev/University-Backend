using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using University_Project.Data;
using University_Project.DTO.User;
using University_Project.Model;
using University_Project.Repository.Interface;
using University_Project.Utility.Mapper;
using University_Project.Utility.PublicClasses;

namespace University_Project.Repository.Impliment
{
    public class UserRepository : IUserRepository
    {
        readonly AppDbContext _context;
        readonly UserManager<User> _userManager;
        readonly Uploader _uploader;
        public UserRepository(AppDbContext context, UserManager<User> userManager, Uploader uploader)
        {
            _context = context;
            _userManager = userManager;
            _uploader = uploader;
        }
        public async Task<GetUserResultDto?> GetById(int id)
        {
            //User? user = await _userManager.FindByIdAsync(id);
            User? user = await _context.users.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
            if (user == null) return null;
            IList<string> roles = await _userManager.GetRolesAsync(user);
            var dto = user.UserToGetUserResultDto();
            dto.roles = roles;
            return dto;
        }
        public async Task<List<GetUserResultDto>> GetAll()
        {
            List<User> users = await _context.users
                .Include(e => e.Department).ToListAsync();
            var dtos = users.Select(user => user.UserToGetUserResultDto()).ToList();
            for (int i = 0; i < dtos.Count; i++)
            {
                dtos[i].roles = await _userManager.GetRolesAsync(users[i]);
            }
            return dtos;
        }
        public async Task<List<Role>> GetRoles()
        {
            List<Role> roles = await _context.roles.ToListAsync();
            return roles;
        }
        public async Task<GetUserFavoAndCoursesDto?> GetFavoAndSignups(int id)
        {
            User? user = await _context.Users.Include(e => e.Signups).Include(e => e.Favorites).FirstOrDefaultAsync(e => e.Id == id);
            if (user == null) return null;
            GetUserFavoAndCoursesDto data = new();
            data.Signups = new();
            data.Favorites = new();
            foreach (var item in user.Favorites)
            {
                var favorite = item.CourseToGetFavorite();
                if (item.NeedSignup == false) favorite.State = "آزاد";
                else favorite.State = "ثبت نامی";
                data.Favorites.Add(favorite);
            }
            foreach (var item in user.Signups)
            {
                var signup = item.CourseToSignedupDto();
                var presence = _context.rollCalls.Where(e => e.UserId == id && e.CourseId == item.Id).Count();
                int time = presence * item.SessionTime;
                signup.AttendedTime = time;
                data.Signups.Add(signup);
            }
            data.Favorites = user.Favorites.Select(e => e.CourseToGetFavorite()).ToList();
            return data;
        }
        public async Task<User?> Update(int id, UpdateUserByAdminDto newUserDto)
        {
            User user = await _userManager.FindByIdAsync(id.ToString());
            User newUser = newUserDto.UpdateUserByAdminDtoToUser(user);
            IdentityResult? userResult = await _userManager.UpdateAsync(newUser);
            await _context.SaveChangesAsync();
            if (!userResult.Succeeded) return null;
            return user;
        }
        public async Task<User?> Edit(int id, UpdateUserDto dto)
        {
            User? user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) return null;
            User newUser = dto.UpdateUserDtoToUser(user);
            if (dto.ProfilePicture != null)
                newUser.ProfilePicture = _uploader.UploadFile(dto.ProfilePicture, "images\\profiles\\");
            IdentityResult? result = await _userManager.UpdateAsync(newUser);
            if (!result.Succeeded) return null;
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> Delete(int id)
        {
            User user = await _userManager.FindByIdAsync(id.ToString());
            IdentityResult deleteResult = await _userManager.DeleteAsync(user);
            await _context.SaveChangesAsync();
            if (!deleteResult.Succeeded) return false;
            return true;
        }
        public async Task<bool> AddFavoriteCourse(int id, int cid)
        {
            try
            {
                Course? course = await _context.courses.FirstOrDefaultAsync(c => c.Id == cid);
                User? user = await _context.users.FirstOrDefaultAsync(u => u.Id == id);
                if (user == null || course == null) return false;
                if (user.Favorites == null) user.Favorites = new List<Course>();
                user.Favorites.Add(course);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> AddSignupCourse(int id, int cid)
        {
            try
            {
                Course? course = await _context.courses.FirstOrDefaultAsync(c => c.Id == cid);
                User? user = await _context.users.FirstOrDefaultAsync(u => u.Id == id);
                if (user == null || course == null) return false;
                if (user.Signups == null) user.Signups = new List<Course>();
                user.Signups.Add(course);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> RemoveFavoriteCourse(int id, int cid)
        {
            try
            {
                Course? course = await _context.courses.FirstOrDefaultAsync(c => c.Id == cid);
                User? user = await _context.users.FirstOrDefaultAsync(u => u.Id == id);
                if (user == null || course == null) return false;
                user.Favorites.Remove(course);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
