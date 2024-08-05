using University_Project.Data;
using University_Project.Model;
using University_Project.Utility.Mapper;
using University_Project.DTO.Department;
using University_Project.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace University_Project.Repository.Impliment
{
    public class DepartmentRepository : IDepartmentRepository
    {
        AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Department>> GetAll()
        {
            return await _context.departments.ToListAsync();
        }

        public async Task<Department?> GetById(int id)
        {
            Department? item = await _context.departments.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null) return null;
            return item;
        }

        public async Task<Department> Create(CreateDepartmentDTO dto)
        {
            Department data = dto.CreateDtoToMainDepartment();
            await _context.departments.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }
        public async Task<Department?> Update(int id, UpdateDepartmentDTO dto)
        {
            Department? data = await _context.departments.FirstOrDefaultAsync(e => e.Id == id);
            if (data == null)
            {
                return null;
            }
            data = dto.UpdateDtoToMainDepartment(data);
            await _context.SaveChangesAsync();
            return data;
        }
        public async Task<bool> DeleteById(int id)
        {
            Department? data = _context.departments.FirstOrDefault(e => e.Id == id);
            if (data == null)
            {
                return false;
            }
            _context.departments.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
