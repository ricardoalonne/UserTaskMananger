using UserTaskMananger.Context;
using UserTaskMananger.UnitOfWork.Structure;

namespace UserTaskMananger.UnitOfWork.Implementation
{
    public class UnitOfWorkAdapter : IUnitOfWorkAdapter
    {
        private readonly UserTaskManangerDbContext _context;

        public IUnitOfWorkRepository Repository { get; }

        public UnitOfWorkAdapter(UserTaskManangerDbContext context)
        {
            this._context = context;
            Repository = new UnitOfWorkRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
