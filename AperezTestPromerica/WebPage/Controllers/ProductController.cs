using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebPage.Controllers
{
    public class ProductController : Controller
    {
        [Authorize(Policy = "AccessProduct")]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
                return RedirectToAction("Index", "Home");

            return View();
        }

        [Authorize(Policy = "AccessProductA")]
        public IActionResult ProductoAPartial()
        {
            return PartialView();
        }
        [Authorize(Policy = "AccessProductB")]
        public IActionResult ProductoBPartial()
        {
            return PartialView();
        }
        [Authorize(Policy = "AccessProductC")]
        public IActionResult ProductoCPartial()
        {
            return PartialView();
        }
    }
}
