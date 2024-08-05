using Microsoft.AspNetCore.Mvc;

namespace University_Project.Controllers.Client
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
