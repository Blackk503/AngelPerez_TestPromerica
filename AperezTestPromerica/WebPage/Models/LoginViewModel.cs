using System.ComponentModel.DataAnnotations;

namespace WebPage.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Ingrese usuario, por favor")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Ingrese contraseña por favor")]
        public string Password { get; set; }
    }
}
