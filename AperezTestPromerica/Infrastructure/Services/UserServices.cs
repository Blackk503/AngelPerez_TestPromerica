using Core.CustomEntities;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class UserServices : IUserServices
    {
        #region ATTRIBUTES
        private readonly PersistenceContext _persistenceContext;
        #endregion

        #region CONSTRUCTOR
        public UserServices(PersistenceContext persistenceContext)
        {
            _persistenceContext = persistenceContext;
        }
        #endregion

        #region METHODS
        public async Task<User> LoginUser(string username, string password)
        {
            User user = await _persistenceContext.Users
                .Where(sig => sig.UserName == username && sig.Password == password)
                .FirstOrDefaultAsync();
            return user;
        }

        public async Task<ProfileUser> GetByUserName(string username)
        {
            var query = await _persistenceContext.Users
                .Join(_persistenceContext.Roles,
                us => us.RoleId,
                r => r.Id,
                (us, r) =>
                new { Users = us, Roles = r })
                .Where(us => us.Users.UserName == username).FirstOrDefaultAsync();
            ProfileUser regUser = new()
            {
                Id = query.Users.Id,
                UserName = query.Users.UserName,
                TypeUser = query.Roles.Name
            };
            return regUser;
        }
        #endregion
    }
}
