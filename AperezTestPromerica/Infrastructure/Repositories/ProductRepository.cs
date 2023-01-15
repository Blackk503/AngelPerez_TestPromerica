using Core.CustomEntities;
using Infrastructure.Interfaces.IRepositories;
using Infrastructure.Interfaces.IServices;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region ATTRIBUTES
        private readonly IProductServices _iProductsServices;
        #endregion

        #region CONSTRUCTOR
        public ProductRepository(IProductServices productServices)
        {
            _iProductsServices = productServices;
        }
        #endregion

        #region METHODS
        public async Task<List<RoleProducts>> GetProductsByRole(string roleName)
        {
            return await _iProductsServices.GetProductsByRole(roleName);
        }
        #endregion
    }
}
