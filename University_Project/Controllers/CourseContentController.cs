using Microsoft.AspNetCore.Mvc;
using University_Project.DTO.CourseContent;
using University_Project.Repository.Interface;

namespace University_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseContentController : ControllerBase
    {
        ICourseContentRepository _repo;
        public CourseContentController(ICourseContentRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("{id}/content")]
        public async Task<IActionResult> GetByCourse(int id)
        {
            List<GetContentDto>? data = await _repo.GetByCourse(id);
            if (data == null) return NoContent();
            return Ok(data);
        }
        [HttpPost("{id}/content/create")]
        public async Task<IActionResult> Create(int id, [FromForm] SendContentDto dto)
        {
            GetContentDto data = await _repo.Create(id, dto);
            if (data == null) return BadRequest();
            return Ok("content created");
        }
        [HttpPut("content/update/{cid}")]
        public async Task<IActionResult> Update(int cid, [FromForm] UpdateContentDto dto)
        {
            GetContentDto? modifiedData = await _repo.Update(cid, dto);
            if(modifiedData == null) return NotFound();
            return Ok(modifiedData);
        }
        [HttpDelete("content/delete/{cid}")]
        public async Task<IActionResult> Delete(int cid)
        {
            bool result = await _repo.Delete(cid);
            if (result) return NoContent();
            return NotFound();
        }
    }
}