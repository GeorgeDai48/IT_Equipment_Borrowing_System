using Microsoft.AspNetCore.Mvc;

namespace IT_Equipment_Borrowing_System.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult RequestForm()
        {
            return View();
        }
    }
}
