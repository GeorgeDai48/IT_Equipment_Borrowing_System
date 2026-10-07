using Microsoft.AspNetCore.Mvc;

namespace IT_Equipment_Borrowing_System.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
