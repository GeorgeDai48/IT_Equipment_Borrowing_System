using System.ComponentModel.DataAnnotations;

namespace IT_Equipment_Borrowing_System.Models
{
    public class Request
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        [Phone]
        public String PhoneNumber { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        public EquipmentType EquipmentType { get; set; }
        [Required]
        [Range(1, 7, ErrorMessage = "Duration must be between 1 and 7 days.")]
        public int Duration { get; set; }
        [Required]
        public String RequestDetails { get; set; }
    }
}
