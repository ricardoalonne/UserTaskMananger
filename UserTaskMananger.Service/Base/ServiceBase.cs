using UserTaskMananger.UnitOfWork.Structure;

namespace UserTaskMananger.Service.Base
{
    public abstract class ServiceBase
    {
        protected IUnitOfWork _unitOfWork;
    }
}
