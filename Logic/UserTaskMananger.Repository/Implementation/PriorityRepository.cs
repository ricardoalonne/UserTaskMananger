using UserTaskMananger.Context;
using UserTaskMananger.Entities;
using UserTaskMananger.Repository.Base;
using UserTaskMananger.Repository.Structure;

namespace UserTaskMananger.Repository.Implementation
{
    public class PriorityRepository : RepositoryBase<Priority>, IPriorityRepository
    {
        public PriorityRepository(UserTaskManangerDbContext context)
        {
            this._context = context;
        }
    }
}
