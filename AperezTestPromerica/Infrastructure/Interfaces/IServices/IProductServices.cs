using Core.CustomEntities;

namespace Infrastructure.Interfaces.IServices
{
    public interface IProductServices
    {
        Task<List<RoleProducts>> GetProductsByRole(string roleName);
    }
}