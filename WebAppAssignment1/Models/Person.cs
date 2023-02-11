using System.ComponentModel.DataAnnotations;

namespace WebAppAssignment1.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; } 

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Surname { get; set; } 

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Make sure you write in email format")]
        public string Email { get; set; } 
    }
}
