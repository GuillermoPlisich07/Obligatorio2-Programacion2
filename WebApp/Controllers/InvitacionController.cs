using Microsoft.AspNetCore.Mvc;
using Obligatorio1;

namespace WebApp.Controllers
{
    public class InvitacionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
