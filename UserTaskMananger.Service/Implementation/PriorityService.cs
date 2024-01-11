using UserTaskMananger.DTOs.Request;
using UserTaskMananger.DTOs.Response;
using UserTaskMananger.Service.Base;
using UserTaskMananger.Service.Structure;
using UserTaskMananger.UnitOfWork.Structure;

namespace UserTaskMananger.Service.Implementation
{
    public class PriorityService : ServiceBase, IPriorityService
    {
        public PriorityService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(PriorityRequest request)
        {
            using (var connection = _unitOfWork.Create())
            {
                var priorityEntity = request.ToEntity();
                await connection.Repository.PriorityRepository.Create(priorityEntity);
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = _unitOfWork.Create())
            {
                await connection.Repository.PriorityRepository.Delete(id);
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

        public async Task<PriorityResponse> FindById(int id)
        {
            using (var connection = _unitOfWork.Create())
            {
                var priorityEntity = await connection.Repository.PriorityRepository.FindById(id);
                var priority = new PriorityResponse(priorityEntity);
                return priority;
            }
        }

        public async Task<IEnumerable<PriorityResponse>> Get()
        {
            using (var connection = _unitOfWork.Create())
            {
                var priorityEntities = await connection.Repository.PriorityRepository.Get();
                var priorities = priorityEntities.Select(priority => new PriorityResponse(priority));
                return priorities;
            }
        }

        public async Task<bool> Update(int id, PriorityRequest request)
        {
            using (var connection = _unitOfWork.Create())
            {
                var currentPriorityEntity = await connection.Repository.PriorityRepository.FindById(id);
                var priorityEntity = request.ToEntity();
                currentPriorityEntity.Copy(priorityEntity);
                connection.Repository.PriorityRepository.Update(currentPriorityEntity);
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }
    }
}
