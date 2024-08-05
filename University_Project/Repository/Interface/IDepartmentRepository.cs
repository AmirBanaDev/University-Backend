using University_Project.Model;
using University_Project.DTO.Department;

namespace University_Project.Repository.Interface
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAll();
        Task<Department?> GetById(int id);
        Task<Department> Create(CreateDepartmentDTO department);
        Task<Department?> Update(int id,UpdateDepartmentDTO department);
        Task<bool> DeleteById(int id);
    }
}
