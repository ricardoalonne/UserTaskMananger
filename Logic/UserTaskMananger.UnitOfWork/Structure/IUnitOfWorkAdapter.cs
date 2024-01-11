namespace UserTaskMananger.UnitOfWork.Structure
{
    public interface IUnitOfWorkAdapter : IDisposable
    {
        IUnitOfWorkRepository Repository { get; }
        Task<int> SaveChanges();
    }
}
