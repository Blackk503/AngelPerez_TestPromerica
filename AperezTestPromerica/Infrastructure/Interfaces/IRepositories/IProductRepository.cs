using Core.CustomEntities;

namespace Infrastructure.Interfaces.IRepositories
{
    public interface IProductRepository
    {
        Task<List<RoleProducts>> GetProductsByRole(string roleName);
    }
}