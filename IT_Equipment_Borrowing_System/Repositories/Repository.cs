using IT_Equipment_Borrowing_System.Models;

namespace IT_Equipment_Borrowing_System.Repositories
{
    public class Repository
    {
        //Equipment List 
        public static List<Equipment> equipments = new List<Equipment>()
        {
            new Equipment() { Id = 1, Name = "Laptop 1", Type = EquipmentType.Laptop, Description = "This is a laptop.", IsAvailable = true },
            new Equipment() { Id = 2, Name = "Laptop 2", Type = EquipmentType.Laptop, Description = "This is a laptop.", IsAvailable = true },
            new Equipment() { Id = 3, Name = "Phone 1", Type = EquipmentType.Phone, Description = "This is a phone.", IsAvailable = true },
            new Equipment() { Id = 4, Name = "Phone 2", Type = EquipmentType.Phone, Description = "This is a phone.", IsAvailable = true },
            new Equipment() { Id = 5, Name = "Tablet 1", Type = EquipmentType.Tablet, Description = "This is a tablet.", IsAvailable = true },
            new Equipment() { Id = 6, Name = "Tablet 2", Type = EquipmentType.Tablet, Description = "This is a tablet.", IsAvailable = true },
            new Equipment() { Id = 7, Name = "Projector 1", Type = EquipmentType.Another, Description = "This is a Projector.", IsAvailable = true },
            new Equipment() { Id = 8, Name = "MP3 Player 1", Type = EquipmentType.Another, Description = "This is a MP3 player.", IsAvailable = true }
        };
        //Requests List
        public static List<Request> requests = new List<Request>();
        //Counter for generating unique request IDs
        static int requestIdCounter = 0;
        public static void AddRequest(Request request)
        {
            //Finds the first available equipment of requested type and marks it as unavailable, then adds it to the requests list with a unique ID
            var equipment = equipments.FirstOrDefault(b => b.Type == request.EquipmentType && b.IsAvailable);
            if (equipment != null)
            {
                equipment.IsAvailable = false;
                requestIdCounter++;
                request.Id = requestIdCounter;
                requests.Add(request);
            }
        }

    }
}
