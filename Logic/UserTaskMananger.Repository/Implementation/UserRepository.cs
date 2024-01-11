using UserTaskMananger.Context;
using UserTaskMananger.Entities;
using UserTaskMananger.Repository.Base;
using UserTaskMananger.Repository.Structure;

namespace UserTaskMananger.Repository.Implementation
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(UserTaskManangerDbContext context)
        {
            this._context = context;
        }
    }
}
