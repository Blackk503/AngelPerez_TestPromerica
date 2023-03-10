using Core.CustomEntities;
using Core.Entities;

namespace Infrastructure.Interfaces.IServices
{
    public interface IUserServices
    {
        Task<User> LoginUser(string username, string password);
        Task<ProfileUser> GetByUserName(string username);
    }
}