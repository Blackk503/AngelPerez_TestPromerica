using Core.CustomClass;
using Core.CustomEntities;
using Core.Entities;
using Core.Interfaces.CustomOperation;
using Infrastructure.Interfaces.IRepositories;
using Infrastructure.Interfaces.IServices;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region ATTRIBUTES
        private readonly IUserServices _iUserServices;
        #endregion

        #region CONSTRUCTOR
        public UserRepository(IUserServices userServices)
        {
            _iUserServices = userServices;
        }
        #endregion

        #region METHODS
        public async Task<IOperationResult<User>> LoginUser(string username, string password)
        {
            User user = await _iUserServices.LoginUser(username, password);
            if (user == null)
                return BasicOperationResult<User>.Fail("El usuario no fue encontrado");
            return BasicOperationResult<User>.Ok(user);
        }

        public async Task<IOperationResult<ProfileUser>> GetByUserName(string username)
        {
            ProfileUser user = await _iUserServices.GetByUserName(username);
            if (user == null)
                return BasicOperationResult<ProfileUser>.Fail("El usuario y su role no fueron encontrados");
            return BasicOperationResult<ProfileUser>.Ok(user);
        }
        #endregion
    }
}
