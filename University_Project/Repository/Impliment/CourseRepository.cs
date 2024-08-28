using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using University_Project.Data;
using University_Project.DTO.Course;
using University_Project.Model;
using University_Project.Repository.Interface;
using University_Project.Utility.Mapper;

namespace University_Project.Repository.Impliment
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<GetCourseDto>> GetAll()
        {
            return await _context.courses.Include(e => e.Department).
                Include(e => e.Type)
                .Select(e => e.CourseToGetDto()).ToListAsync();
        }

        public async Task<GetCourseDto?> GetById(int id)
        {
            Course? item = await _context.courses.Include(e => e.Department).
                Include(e=>e.Type)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (item == null) return null;
            return item.CourseToGetDto();
        }
        public async Task<GetCourseDto?> GetByDepartment(int id)
        {
            Course? item = await _context.courses.Include(e => e.Department).
                Include(e => e.Type)
                .FirstOrDefaultAsync(e => e.DepartmentId == id);
            if (item == null) return null;
            return item.CourseToGetDto();
        }
        public async Task<GetCourseDto?> Create(CreateCourseDto dto)
        {
            try
            {
                Course item = dto.CreateDtoToCourse();
                item.Type = await _context.coursesType.FirstOrDefaultAsync( e=>e.Id == dto.TypeId );
                item.Department = await _context.departments.FirstOrDefaultAsync(e => e.Id == dto.DepartmentId);
                await _context.courses.AddAsync(item);
                await _context.SaveChangesAsync();
                return item.CourseToGetDto();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<GetCourseDto?> Update(int id, UpdateCourseDto dto)
        {
            Course? item = await _context.courses.Include(e => e.Department).
                Include(e => e.Type)
                .FirstOrDefaultAsync(c => c.Id == id);
            if(item == null) return null;
            item = dto.UpdateDtoToCourse(item);
            item.Type = await _context.coursesType.FirstOrDefaultAsync(e => e.Id == dto.TypeId);
            await _context.SaveChangesAsync();
            return item.CourseToGetDto();
        }
        public async Task<bool> DeleteById(int id)
        {
            Course? item = await _context.courses.Include(e => e.Department).
                Include(e => e.Type).FirstOrDefaultAsync(c => c.Id == id);
            if (item == null) return false;
            _context.courses.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> FinishCourse(int id)
        {
            Course? item = await _context.courses.FirstOrDefaultAsync(c => c.Id == id);
            if (item == null) return false;
            item.IsFinished = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
