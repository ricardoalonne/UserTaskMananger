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

        public override IEnumerable<UserTask> Find(Func<UserTask, bool> isMatched)
        {
            return _context.UserTasks.Include(usertask => usertask.User)
                                      .Include(usertask => usertask.Priority)
                                      .Where(isMatched);
        }

        public async Task<IEnumerable<UserTask>> GetByUserIdAndMode(int userId, string mode)
        {
            var userTask = await Get();
            
            if (userId > 0)
            {
                userTask = userTask.Where(userTask => userTask.UserId == userId);
            }

            if (mode == "pending")
            {
                userTask = userTask.Where(userTask => !userTask.Finished && !userTask.Deleted);
            }

            if (mode == "finished")
            {
                userTask = userTask.Where(userTask => userTask.Finished);
            }

            if (mode == "deleted")
            {
                userTask = userTask.Where(userTask => userTask.Deleted);
            }

            return userTask;
        }
    }
}
