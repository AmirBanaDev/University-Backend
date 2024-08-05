using System.Runtime.CompilerServices;
using University_Project.DTO.Department;
using University_Project.Model;

namespace University_Project.Utility.Mapper
{
    public static class DepartmentMapper
    {
        public static GetDepartmentDTO ToGetDTO(this Department department)
        {
            return new GetDepartmentDTO
            {
                Id = department.Id,
                Name = department.Name
            };
        }
        public static Department CreateDtoToMainDepartment(this CreateDepartmentDTO dto)
        {
            return new Department
            {
                Name = dto.Name
            };
        }
        public static Department UpdateDtoToMainDepartment(this UpdateDepartmentDTO dto,Department item)
        {
            item.Name = dto.Name;
            return item;
        }
    }
}