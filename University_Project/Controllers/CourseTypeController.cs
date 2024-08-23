using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using University_Project.Data;
using University_Project.DTO.CourseType;
using University_Project.Model;
using University_Project.Repository.Interface;

namespace University_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseTypeController : ControllerBase
    {
        private readonly ICourseTypeRepository _repo;
        public CourseTypeController(ICourseTypeRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<CourseType> courses = await _repo.GetAll();
            return Ok(courses);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            CourseType? data = await _repo.GetById(id);
            if(data == null) return NotFound();
            return Ok(data);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CourseTypeDto data)
        {
            try
            {
                CourseType result = await _repo.Create(data);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CourseTypeDto data)
        {
            CourseType? modified = await _repo.Update(id, data);
            if(modified == null) return NotFound();
            return CreatedAtAction(nameof(GetById), new { id = modified.Id }, modified);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _repo.DeleteById(id);
            if(!isDeleted) return NotFound();
            return NoContent();
        }
    }
}
