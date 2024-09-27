using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using University_Project.Model;
using University_Project.Repository.Interface;

namespace University_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RollCallController : ControllerBase
    {
        IRollCallRepository _repo;
        public RollCallController(IRollCallRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("course/{id}")]
        public async Task<IActionResult> GetByCourseId(int courseId)
        {
            List<RollCall>? data = await _repo.GetByCourseId(courseId);
            if(data == null) return NotFound();
            return Ok(data);
        }
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            List<RollCall>? data = await _repo.GetByUserId(userId);
            if(data == null) return NotFound();
            return Ok(data);
        }
        [HttpPost("/present")]
        public async Task<IActionResult> Create([FromBody] List<RollCall> data)
        {
            try
            {
                string result = await _repo.CreatePresent(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("/Absent")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            try
            {
                string result = await _repo.DeleteAbsent(ids);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
