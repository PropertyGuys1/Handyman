namespace Handyman.Data.Entities
{
    public class Address
    {
        public Guid AddressID { get; set; }
        public string? UserID { get; set; }
        public string? Country { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? StreetAddress { get; set; }
        public string? AptSuite { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? PostalCode { get; set; }
        public string? Instructions { get; set; }
        public bool IsDeleted { get; set; }

        // Navigation property
        public UserProfile? UserProfile { get; set; }
    }
}