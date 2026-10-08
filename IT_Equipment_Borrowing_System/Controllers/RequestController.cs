using IT_Equipment_Borrowing_System.Models;
using IT_Equipment_Borrowing_System.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IT_Equipment_Borrowing_System.Controllers
{
    public class RequestController : Controller
    {
        [Route("RequestForm")]
        public IActionResult RequestForm()
        {
            return View();
        }
        [Route("RequestForm")]
        [HttpPost]
        public IActionResult RequestForm(Request request) 
        {
            //Will reject request if the same email has already requested the same equipment type (different type is allowed)
            Boolean isAlreadyRequestedEmail = Repository.requests.Any(r => r.Email == request.Email && r.EquipmentType == request.EquipmentType);
            if (isAlreadyRequestedEmail)
            {
                ModelState.AddModelError("Email", "You have already requested this equipment type.");
                return View("RequestForm", request);
            }

            //Will reject request if the same phone number has already requested the same equipment type (different type is allowed)
            Boolean isAlreadtRequestedPhone = Repository.requests.Any(r => r.PhoneNumber == request.PhoneNumber && r.EquipmentType == request.EquipmentType);
            if (isAlreadtRequestedPhone)
            {
                ModelState.AddModelError("PhoneNumber", "You have already requested this equipment type.");
                return View("RequestForm", request);
            }

            //Will reject request if there are no available equipment of the requested type
            Boolean isEquipmentAvailable = Repository.equipments.Any(e => e.Type == request.EquipmentType && e.IsAvailable);
            if (!isEquipmentAvailable)
            {
                ModelState.AddModelError("EquipmentType", "This type of equipment is not available.");
                return View("RequestForm", request);
            }
            if (ModelState.IsValid)
            {
                Repository.AddRequest(request);
                //Sends the user to a confirmation page with request details
                return View("RequestConfirmation", request);
            }

            return View("RequestForm", request);
        }

        //Admin page to view requests
        [Route("Requests")]
        public IActionResult adminPage()
        {
            return View("Requests", Repository.requests);
        }
    }
}
