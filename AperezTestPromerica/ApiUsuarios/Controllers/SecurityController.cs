using Core.CustomEntities;
using Core.DTOS;
using Core.Entities;
using Core.Interfaces.CustomOperation;
using Infrastructure.Interfaces.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiUsuarios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityController : ControllerBase
    {
        #region ATTRIBUTES
        private readonly IConfiguration _config;
        private readonly IUserRepository _iUserRepository;
        #endregion

        #region CONSTRUCTOR
        public SecurityController(
            IConfiguration config,
            IUserRepository iUserRepository)
        {
            _config = config;
            _iUserRepository = iUserRepository;
        }

        #endregion

        #region METHODS
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("ValidarCredenciales")]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDto loginModel)
        {
            IOperationResult<User> result = await _iUserRepository.LoginUser(loginModel.UserName, loginModel.Password);
            if (!result.Success)
            {
                return Ok(new { Code = StatusCodes.Status404NotFound, Message = "No se encontro el usuario" });
            }

            return Ok(new
            {
                Code = 1,
                Data = true
            });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("ObtenerRolesUsuario")]
        public async Task<IActionResult> GetRoleXUser([FromBody] string user)
        {
            IOperationResult<ProfileUser> result = await _iUserRepository.GetByUserName(user);
            if (!result.Success)
            {
                return Ok(new { Code = StatusCodes.Status404NotFound, Message = "No se encontro el role del usuario" });
            }

            string tokenString = BuildTaxPayerToken(result.Entity);

            return Ok(new
            {
                Code = 1,
                Data = tokenString
            });
        }

        private string BuildTaxPayerToken(ProfileUser profile)
        {
            DateTime expirationDate = DateTime.Now.AddMinutes(5);
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, profile.UserName),
                new Claim(ClaimTypes.Role, profile.TypeUser)
                // Add some values
                //new Claim("nameFild", Convert.ToBase64String(Encoding.UTF8.GetBytes(profile.xxxxxx)))
            };

            string tokenUrl = _config.GetSection("Token:Url").Value;

            var token = new JwtSecurityToken(tokenUrl,
                tokenUrl,
                expires: expirationDate,
                claims: claims,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion

    }
}
