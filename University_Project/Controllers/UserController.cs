using Microsoft.AspNetCore.Mvc;
using University_Project.DTO.User;
using University_Project.Model;
using University_Project.Repository.Interface;
using University_Project.Utility.Mapper;

namespace University_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            GetUserResultDto? user = await _userRepo.GetById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            List<GetUserResultDto> users = await _userRepo.GetAll();
            if (users.Count == 0) return Ok("User List Is Empty");
            return Ok(users);
        }
        [HttpGet("favosign/{id}")]
        public async Task<IActionResult> GetFavoAndSigns(int id)
        {
            GetUserFavoAndCoursesDto? data = await _userRepo.GetFavoAndSignups(id);
            if (data == null) return NotFound();
            return Ok(data);
        }
        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            List<Role> roles = await _userRepo.GetRoles();
            return Ok(roles);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserByAdminDto dto)
        {
            User? modifiedData = await _userRepo.Update(id, dto);
            if (modifiedData == null)
                return NotFound();
            return CreatedAtAction(nameof(GetById), new { id = modifiedData.Id }, modifiedData.UserToGetUserResultDto());
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _userRepo.Delete(id);
            if (!result) return NotFound();
            return Ok("User Deleted");
        }
        [HttpPatch("{id}/favo/{cid}")]
        public async Task<IActionResult> AddFavoriteCourse(int id, int cid)
        {
            bool result = await _userRepo.AddFavoriteCourse(id, cid);
            if (!result) return NotFound();
            return NoContent();
        }
        [HttpPatch("{id}/sign/{cid}")]
        public async Task<IActionResult> AddSignupCourse(int id, int cid)
        {
            bool result = await _userRepo.AddSignupCourse(id, cid);
            if (!result) return NotFound();
            return NoContent();
        }
        [HttpPatch("{id}/favo/{cid}/remove")]
        public async Task<IActionResult> RemoveFavoriteCourse(int id, int cid)
        {
            bool result = await _userRepo.RemoveFavoriteCourse(id, cid);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
