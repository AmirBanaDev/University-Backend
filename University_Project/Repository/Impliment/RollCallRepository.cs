using Microsoft.EntityFrameworkCore;
using University_Project.Data;
using University_Project.DTO.User;
using University_Project.Model;
using University_Project.Repository.Interface;

namespace University_Project.Repository.Impliment
{
    public class RollCallRepository : IRollCallRepository
    {
        AppDbContext _context;
        public RollCallRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<RollCall>?> GetByCourseId(int id)
        {
            List<RollCall>? rollCalls = await _context.rollCalls.Where(e=>e.CourseId == id).ToListAsync();
            if (rollCalls == null) return null;
            return rollCalls;
        }
        public async Task<List<RollCall>?> GetByUserId(int id)
        {
            List<RollCall>? rollCalls = await _context.rollCalls.Where(e => e.UserId == id).ToListAsync();
            if (rollCalls == null) return null;
            return rollCalls;
        }
        public async Task<string> CreatePresent(List<RollCall> rollCalls)
        {
            try
            {
                List<RollCall> newRollCalls = new List<RollCall>();
                foreach (var item in rollCalls)
                {
                    var chk = await _context.rollCalls.FirstOrDefaultAsync(e => e.UserId == item.UserId && e.CourseId == item.CourseId);
                    if (chk != null) continue;
                    newRollCalls.Add(item);
                }
                await _context.rollCalls.AddRangeAsync(newRollCalls);
                await _context.SaveChangesAsync();
                return "All Checked";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }

        }

        public async Task<string> DeleteAbsent(List<int> id)
        {
            try
            {
                _context.RemoveRange(id);
                await _context.SaveChangesAsync();
                return "All Checked";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }
    }
}
