using Core.CustomEntities;
using Core.Entities;
using Core.Interfaces.CustomOperation;

namespace Infrastructure.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<IOperationResult<User>> LoginUser(string username, string password);
        Task<IOperationResult<ProfileUser>> GetByUserName(string username);
    }
}