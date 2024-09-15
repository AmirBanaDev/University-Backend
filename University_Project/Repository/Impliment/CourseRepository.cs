using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using University_Project.Data;
using University_Project.DTO.Course;
using University_Project.Model;
using University_Project.Repository.Interface;
using University_Project.Utility.Mapper;
using University_Project.Utility.PublicClasses;

namespace University_Project.Repository.Impliment
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        private readonly Uploader _uploader;
        public CourseRepository(AppDbContext context, Uploader uploader)
        {
            _context = context;
            _uploader = uploader;
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
        public async Task<List<GetCourseDto>> GetByDepartment(int id)
        {
            List<Course> item = await _context.courses.Include(e => e.Department).
                Include(e => e.Type)
                .ToListAsync();
            if (item == null) return null;
            return item.Where(e => e.DepartmentId == id).Select(e=>e.CourseToGetDto()).ToList();
        }
        public async Task<GetCourseDto?> Create(CreateCourseDto dto)
        {
            try
            {
                Course item = dto.CreateDtoToCourse();
                Console.WriteLine("----item:"+ item.Banner);
                item.Banner = _uploader.UploadFile(dto.Banner, "images\\courses\\");
                item.Type = await _context.coursesType.FirstOrDefaultAsync( e=>e.Id == dto.TypeId );
                item.Department = await _context.departments.FirstOrDefaultAsync(e => e.Id == dto.DepartmentId);
                await _context.courses.AddAsync(item);
                await _context.SaveChangesAsync();
                return item.CourseToGetDto();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
            item.Banner = _uploader.UploadFile(dto.Banner, @"images/courses/");
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
