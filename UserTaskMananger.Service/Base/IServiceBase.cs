namespace UserTaskMananger.Service.Base
{
    public interface IServiceBase<TResponse, TRequest>
    {
        Task<IEnumerable<TResponse>> Get();
        Task<TResponse> FindById(int id);
        Task<bool> Create(TRequest request);
        Task<bool> Update(int id, TRequest request);
        Task<bool> Delete(int id);
    }
}
