using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CardholderManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [JsonIgnore]
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
