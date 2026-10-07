namespace IT_Equipment_Borrowing_System.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public EquipmentType Type { get; set; }
        public String Description { get; set; }
        public Boolean IsAvailable { get; set; }

    }
}
