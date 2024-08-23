using Microsoft.EntityFrameworkCore;
using University_Project.Data;
using University_Project.DTO.CourseType;
using University_Project.Model;
using University_Project.Repository.Interface;
using University_Project.Utility.Mapper;

namespace University_Project.Repository.Impliment
{
    public class CourseTypeRepository : ICourseTypeRepository
    {
        AppDbContext _context;
        public CourseTypeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<CourseType>> GetAll()
        {
            return await _context.coursesType.ToListAsync();
        }

        public async Task<CourseType?> GetById(int id)
        {
            CourseType? item = await _context.coursesType.FirstOrDefaultAsync(c => c.Id == id);
            if (item == null) return null;
            return item;
        }
        public async Task<CourseType> Create(CourseTypeDto data)
        {
            await _context.coursesType.AddAsync(data.CourseTypeDtoToModel());
            await _context.SaveChangesAsync();
            return data.CourseTypeDtoToModel();
        }
        public async Task<CourseType?> Update(int id, CourseTypeDto newData)
        {
            CourseType? data = await _context.coursesType.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null) return null;
            data = newData.UpdateDtoToModel(data);
            await _context.SaveChangesAsync();
            return data;
        }
        public async Task<bool> DeleteById(int id)
        {
            CourseType? data = await _context.coursesType.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null) return false;
            _context.coursesType.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
