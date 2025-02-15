namespace Handyman.Data.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        
        public byte[]? ProfileImage { get; set; } // Path to the uploaded image


        public string? Address { get; set; }
        public string? Role { get; set; } // "Customer" or "Provider"
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public string? Password { get; set; }

        // Navigation properties
        public virtual CustomerProfile CustomerProfile { get; set; }
        public virtual ProviderProfile ProviderProfile { get; set; }
    }
}
