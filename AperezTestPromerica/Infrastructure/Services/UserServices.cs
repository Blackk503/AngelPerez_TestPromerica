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
        #endregion
    }
}
