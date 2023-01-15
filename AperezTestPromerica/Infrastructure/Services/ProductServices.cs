using Core.CustomEntities;
using Infrastructure.Data;
using Infrastructure.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class ProductServices : IProductServices
    {
        #region ATTRIBUTES
        private readonly PersistenceContext _persistenceContext;
        #endregion

        #region CONSTRUCTOR
        public ProductServices(
            PersistenceContext persistenceContext)
        {
            _persistenceContext = persistenceContext;
        }
        #endregion

        #region METHODS
        public async Task<List<RoleProducts>> GetProductsByRole(string roleName)
        {
            var rrr = await _persistenceContext.Roles.ToListAsync();
            var query = await _persistenceContext.Roles
                .Join(_persistenceContext.Products,
                ro => ro.Id,
                pr => pr.RoleId,
                (ro, pr) =>
                new { Roles = ro, Products = pr })
                .Where(ro => ro.Roles.Name == roleName).ToListAsync();
            List<RoleProducts> lstProducts = query.Select(x => new RoleProducts()
            {
                RoleName = x.Roles.Name,
                ProductName = x.Products.Name
            }).ToList();
            return lstProducts;
        }
        #endregion
    }
}
