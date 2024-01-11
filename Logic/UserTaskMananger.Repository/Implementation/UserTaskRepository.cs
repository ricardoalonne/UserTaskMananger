using Microsoft.EntityFrameworkCore;
using UserTaskMananger.Context;
using UserTaskMananger.Entities;
using UserTaskMananger.Repository.Base;
using UserTaskMananger.Repository.Structure;

namespace UserTaskMananger.Repository.Implementation
{
    public class UserTaskRepository : RepositoryBase<UserTask>, IUserTaskRepository
    {
        public UserTaskRepository(UserTaskManangerDbContext context)
        {
            this._context = context;
        }

        public override async Task<UserTask> FindById(int id)
        {
            return await _context.UserTasks.Include(userTask => userTask.User)
                                    .Include(userTask => userTask.Priority)
                                    .FirstAsync(userTask => userTask.Id == id);
        }

        public override async Task<IEnumerable<UserTask>> Get()
        {
            return await _context.UserTasks.Include(usertask => usertask.User)
                                   .Include(usertask => usertask.Priority).ToListAsync();
        }
    }
}
