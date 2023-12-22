using System.ComponentModel.DataAnnotations;

namespace DoctorsApi.Models
{
    public class Doctors
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;

    }
}
