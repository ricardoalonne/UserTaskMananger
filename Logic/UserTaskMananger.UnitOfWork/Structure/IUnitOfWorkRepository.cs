using UserTaskMananger.Repository.Structure;

namespace UserTaskMananger.UnitOfWork.Structure
{
    public interface IUnitOfWorkRepository
    {
        public IUserRepository UserRepository { get; set; }
        public IPriorityRepository PriorityRepository { get; set; }
        public IUserTaskRepository UserTaskRepository { get; set; }
    }
}
