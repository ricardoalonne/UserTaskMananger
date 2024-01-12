using UserTaskMananger.Entities;
using UserTaskMananger.Repository.Base;

namespace UserTaskMananger.Repository.Structure
{
    public interface IUserTaskRepository : IRepositoryBase<UserTask>
    {
        Task<IEnumerable<UserTask>> GetByUserIdAndMode(int userId, string mode);
    }
}
