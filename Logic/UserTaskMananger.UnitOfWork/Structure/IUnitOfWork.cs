namespace UserTaskMananger.UnitOfWork.Structure
{
    public interface IUnitOfWork
    {
        IUnitOfWorkAdapter Create();
    }
}
