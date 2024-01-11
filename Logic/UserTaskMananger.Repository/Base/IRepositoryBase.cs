namespace UserTaskMananger.Repository.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        Task Create(T entity);
        //Task Update(int id, T entity);
        void Update(T entity);
        Task Delete(int id);
        Task<T> FindById(int id);
        Task<IEnumerable<T>> Get();
    }
}
