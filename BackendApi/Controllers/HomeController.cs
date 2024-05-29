using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet] //Er nød til at have en get her for ellers vil swagger ikke være med
        public IActionResult Index()
        {
            return View();
        }
    }
}
