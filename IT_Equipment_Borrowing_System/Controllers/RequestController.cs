using IT_Equipment_Borrowing_System.Models;
using IT_Equipment_Borrowing_System.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IT_Equipment_Borrowing_System.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult RequestForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RequestForm(Request request) 
        {
            Boolean isAlreadyRequestedEmail = Repository.requests.Any(r => r.Email == request.Email && r.EquipmentType == request.EquipmentType);
            if (isAlreadyRequestedEmail)
            {
                ModelState.AddModelError("Email", "You have already requested this equipment type.");
                return View("RequestForm", request);
            }
            
            Boolean isAlreadtRequestedPhone = Repository.requests.Any(r => r.PhoneNumber == request.PhoneNumber && r.EquipmentType == request.EquipmentType);
            if (isAlreadtRequestedPhone)
            {
                ModelState.AddModelError("PhoneNumber", "You have already requested this equipment type.");
                return View("RequestForm", request);
            }
            Boolean isEquipmentAvailable = Repository.equipments.Any(e => e.Type == request.EquipmentType && e.IsAvailable);
            if (!isEquipmentAvailable)
            {
                ModelState.AddModelError("EquipmentType", "This type of equipment is not available.");
                return View("RequestForm", request);
            }
            if (ModelState.IsValid)
            {
                Repository.AddRequest(request);
                return View("RequestConfirmation", request);
            }

            return View("RequestForm", request);
        }
        [Route("Requests")]
        public IActionResult adminPage()
        {
            return View("Requests", Repository.requests);
        }
    }
}
