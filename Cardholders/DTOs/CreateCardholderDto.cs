using System.ComponentModel.DataAnnotations;

namespace CardholderManagementSystem.DTOs
{
    public sealed class CreateCardholderDto
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = String.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = String.Empty;

        [Required, MaxLength(200)]
        public string Address { get; set; } = String.Empty;

        [Required, MaxLength(30)]
        [RegularExpression(@"^\+[0-9]{6,15}$", ErrorMessage = "Phone number must start with + and contain only digits, no spaces.")]
        public string PhoneNumber { get; set; } = String.Empty;

        [Required]
        public uint TransactionCount { get; set; }
    }
}
