using UserTaskMananger.DTOs.Request;
using UserTaskMananger.DTOs.Response;
using UserTaskMananger.Service.Base;
using UserTaskMananger.Service.Structure;
using UserTaskMananger.UnitOfWork.Structure;

namespace UserTaskMananger.Service.Implementation
{
    public class UserTaskService : ServiceBase, IUserTaskService
    {
        public UserTaskService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(UserTaskRequest request)
        {
            using (var connection = _unitOfWork.Create())
            {
                request.SetTimeOnCreation();
                var userTaskEntity = request.ToEntity();
                await connection.Repository.UserTaskRepository.Create(userTaskEntity);
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = _unitOfWork.Create())
            {
                await connection.Repository.UserTaskRepository.Delete(id);
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

        public async Task<UserTaskResponse> FindById(int id)
        {
            using (var connection = _unitOfWork.Create())
            {
                var userTaskEntity = await connection.Repository.UserTaskRepository.FindById(id);
                var userTask = new UserTaskResponse(userTaskEntity);
                return userTask;
            }
        }

        public async Task<IEnumerable<UserTaskResponse>> Get()
        {
            using (var connection = _unitOfWork.Create())
            {
                var userTaskEntities = await connection.Repository.UserTaskRepository.Get();
                var userTasks = userTaskEntities.Select(userTask => new UserTaskResponse(userTask));
                return userTasks;
            }
        }

        public async Task<bool> Update(int id, UserTaskRequest request)
        {
            using (var connection = _unitOfWork.Create())
            {
                request.SetTimeOnUpdation();
                var currentUserTaskEntity = await connection.Repository.UserTaskRepository.FindById(id);
                var userTaskEntity = request.ToEntity();
                currentUserTaskEntity.Copy(userTaskEntity);
                connection.Repository.UserTaskRepository.Update(currentUserTaskEntity);
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }
    }
}
