using Core.CustomEntities;
using Infrastructure.Interfaces.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiProductos.Controllers.Product
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        #region ATTRIBUTES
        private readonly IProductRepository _iProductRepository;
        #endregion

        #region CONSTRUCTOR
        public ProductController(IProductRepository productRepository)
        {
            _iProductRepository = productRepository;
        }
        #endregion

        #region METHODS
        [HttpGet("ProductosxRol")]
        public async Task<IActionResult> GetProductsByRoles(string roleName)
        {
            List<RoleProducts> result = await _iProductRepository.GetProductsByRole(roleName);
            return Ok(new
            {
                Code = 1,
                Data = result
            });
        }
        #endregion
    }
}
