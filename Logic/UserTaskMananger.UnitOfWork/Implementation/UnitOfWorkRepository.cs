using UserTaskMananger.Context;
using UserTaskMananger.Repository.Implementation;
using UserTaskMananger.Repository.Structure;
using UserTaskMananger.UnitOfWork.Structure;

namespace UserTaskMananger.UnitOfWork.Implementation
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IUserRepository UserRepository { get; set; }
        public IPriorityRepository PriorityRepository { get; set; }
        public IUserTaskRepository UserTaskRepository { get; set; }

        public UnitOfWorkRepository(UserTaskManangerDbContext context)
        {
            UserRepository = new UserRepository(context);
            PriorityRepository = new PriorityRepository(context);
            UserTaskRepository = new UserTaskRepository(context);
        }
    }
}
