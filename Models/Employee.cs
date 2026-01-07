using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DOB { get; set; } = DateTime.UtcNow;
    }
}

