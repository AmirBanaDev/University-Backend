using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_Project.Data;
using University_Project.DTO.Department;
using University_Project.Model;
using University_Project.Repository.Interface;
using University_Project.Utility.Mapper;

namespace University_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IDepartmentRepository _repoDepartment;
        public DepartmentController(AppDbContext context, IDepartmentRepository repDep)
        {
            _context = context;
            _repoDepartment = repDep;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Department> departments = await _context.departments.ToListAsync();
            IEnumerable<GetDepartmentDTO> departmentDTO = departments.Select(e => e.ToGetDTO());
            return Ok(departmentDTO);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Department? department = await _repoDepartment.GetById(id);
            if(department == null)
            {
                return NotFound();
            }
            return Ok(department.ToGetDTO());
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentDTO dto)
        {
            Department data = await _repoDepartment.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = data.Id }, data.ToGetDTO());
        }
        [HttpPut("update/{id}")]
       // [Route("/{id}")]
        public async Task<IActionResult> UpdateDepartment(int id,[FromBody] UpdateDepartmentDTO dto)
        {
            Department? modifiedData = await _repoDepartment.Update(id, dto);
            if(modifiedData == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetById),new {id = modifiedData.Id}, modifiedData.ToGetDTO());
        }
        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> RemoveItem(int id)
        {
            bool isDeleted = await _repoDepartment.DeleteById(id);
            if(!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
