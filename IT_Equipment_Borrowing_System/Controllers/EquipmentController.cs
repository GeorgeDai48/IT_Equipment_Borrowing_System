using IT_Equipment_Borrowing_System.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IT_Equipment_Borrowing_System.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult AllEquipment()
        {
            var equipmentList = Repository.equipments;
            return View(equipmentList);
        }

    }
}
