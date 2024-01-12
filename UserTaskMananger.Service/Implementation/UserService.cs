using UserTaskMananger.DTOs.Request;
using UserTaskMananger.DTOs.Response;
using UserTaskMananger.Service.Base;
using UserTaskMananger.Service.Structure;
using UserTaskMananger.UnitOfWork.Structure;

namespace UserTaskMananger.Service.Implementation
{
    public class UserService : ServiceBase, IUserService
    {
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(UserRequest request)
        {
            using (var connection = _unitOfWork.Create())
            {
                request.SetTimeOnCreation();
                var userEntity = request.ToEntity();
                await connection.Repository.UserRepository.Create(userEntity);
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = _unitOfWork.Create())
            {
                await connection.Repository.UserRepository.Delete(id);
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

        public async Task<UserResponse> FindById(int id)
        {
            using (var connection = _unitOfWork.Create())
            {
                var userEntity = await connection.Repository.UserRepository.FindById(id);
                var user = new UserResponse(userEntity);
                return user;
            }
        }

        public async Task<IEnumerable<UserResponse>> Get()
        {
            using (var connection = _unitOfWork.Create())
            {
                var userEntities = await connection.Repository.UserRepository.Get();
                var users = userEntities.Select(user => new UserResponse(user));
                return users;
            }
        }

        public async Task<int> GetTotal()
        {
            using (var connection = _unitOfWork.Create())
            {
                var total = await connection.Repository.UserRepository.GetTotal();
                return total;
            }
        }
        public async Task<bool> Update(int id, UserRequest request)
        {
            using (var connection = _unitOfWork.Create())
            {
                request.SetTimeOnUpdation();
                var currentUserEntity = await connection.Repository.UserRepository.FindById(id);
                currentUserEntity.Copy(request.ToEntity());
                connection.Repository.UserRepository.Update(currentUserEntity);
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }
    }
}
