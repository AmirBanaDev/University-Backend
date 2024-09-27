using University_Project.Model;

namespace University_Project.Repository.Interface
{
    public interface IRollCallRepository
    {
        public Task<List<RollCall>?> GetByCourseId(int id);
        public Task<List<RollCall>?> GetByUserId(int id);
        public Task<string> CreatePresent(List<RollCall> rollCalls);
        public Task<string> DeleteAbsent(List<int> id);
    }
}
