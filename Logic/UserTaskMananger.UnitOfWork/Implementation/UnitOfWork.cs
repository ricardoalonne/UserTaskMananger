using UserTaskMananger.Context;
using UserTaskMananger.UnitOfWork.Structure;

namespace UserTaskMananger.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly UserTaskManangerDbContext _context;

        public UnitOfWork(UserTaskManangerDbContext context)
        {
            this._context = context;
        }

        public IUnitOfWorkAdapter Create()
        {
            return new UnitOfWorkAdapter(_context);
        }
    }
}
