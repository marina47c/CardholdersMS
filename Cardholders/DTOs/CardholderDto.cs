namespace CardholderManagementSystem.DTOs
{
    public sealed class CardholderDto
    {
        public uint Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public uint TransactionCount { get; set; }
    }
}
