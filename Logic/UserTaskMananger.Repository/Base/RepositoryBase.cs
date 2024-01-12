using Microsoft.EntityFrameworkCore;
using System.Xml;
using UserTaskMananger.Context;

namespace UserTaskMananger.Repository.Base
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected UserTaskManangerDbContext _context;

        public async Task Create(T entity)
        {
            await _context.AddAsync(entity);
        }

        //public async Task Update(int id, T entity)
        //{
        //    var obj = await _context.Set<T>().FindAsync(id);
        //    obj = entity;
        //}

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public async Task Delete(int id)
        {
            var obj = await _context.Set<T>().FindAsync(id);
            _context.Remove(obj);
        }

        public virtual IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }


        public virtual async Task<T> FindById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<int> GetTotal()
        {
            return await _context.Set<T>().CountAsync();
        }
    }
}
