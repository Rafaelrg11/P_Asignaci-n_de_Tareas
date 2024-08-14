using Microsoft.AspNetCore.Mvc;

namespace P_Asignación_de_Tareas.Controllers
{
    public class ModuleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
