using System.ComponentModel.DataAnnotations;

namespace RESTApiCRUDDemo.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Name can only be 50 characters long")]
        public String Name { get; set; }
    }
}
