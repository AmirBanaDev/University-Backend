using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_Project.DTO.Course;
using University_Project.Model;
using University_Project.Repository.Impliment;
using University_Project.Repository.Interface;

namespace University_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        ICourseRepository _repo;
        public CourseController(ICourseRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<GetCourseDto> courses = await _repo.GetAll();
            return Ok(courses);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetCourseDto? course = await _repo.GetById(id);
            if(course == null) return NotFound();
            return Ok(course);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCourseDto dto)
        {
            GetCourseDto? data = await _repo.Create(dto);
            if (data == null) return BadRequest();
            return CreatedAtAction(nameof(GetById), new { id = data.Id }, data);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCourseDto dto)
        {
            GetCourseDto? modifiedData = await _repo.Update(id, dto);
            if(modifiedData == null) return NotFound();
            return CreatedAtAction(nameof(GetById), new {id =  modifiedData.Id}, modifiedData);
        }
        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> RemoveItem(int id)
        {
            bool isDeleted = await _repo.DeleteById(id);
            if(!isDeleted) return NotFound();
            return NoContent();
        }
        [HttpPut("{id}/finish")]
        public async Task<IActionResult> FinishCourse(int id)
        {
            bool isFinished = await _repo.FinishCourse(id);
            if(!isFinished) return NotFound();
            return NoContent();
        }
    }
}
