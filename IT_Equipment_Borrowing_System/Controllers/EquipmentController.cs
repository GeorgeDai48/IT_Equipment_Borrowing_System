using IT_Equipment_Borrowing_System.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IT_Equipment_Borrowing_System.Controllers
{
    public class EquipmentController : Controller
    {
        [Route("AllEquipment")]
        public IActionResult AllEquipment()
        {
            //passes a list of all the equipment to the view
            var equipmentList = Repository.equipments;
            return View(equipmentList);
        }
        
        [Route("AvailableEquipment")]
        public IActionResult AvailableEquipment()
        {
            //Only passes the list of equipment that is available to the view
            var availableEquipmentList = Repository.equipments.Where(e => e.IsAvailable).ToList();
            return View(availableEquipmentList);
        }

    }
}
