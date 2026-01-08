using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public DateTime DOB { get; set; } = DateTime.UtcNow;
    }
}
