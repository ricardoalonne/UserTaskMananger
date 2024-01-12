using UserTaskMananger.DTOs.Request;
using UserTaskMananger.DTOs.Response;
using UserTaskMananger.Entities;
using UserTaskMananger.Service.Base;

namespace UserTaskMananger.Service.Structure
{
    public interface IUserTaskService : IServiceBase<UserTaskResponse, UserTaskRequest>
    {
        Task<IEnumerable<UserTaskResponse>> GetByUserIdAndMode(int userId, string mode);
        Task<bool> Remove(int id);
        Task<bool> Finish(int id);
    }
}
