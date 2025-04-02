using Handyman.Data.Entities;

namespace Handyman.Models
{
    public class ProviderProfileViewModel
    {
        // Profile Model Fields
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public bool Active { get; set; } = true;

        // ProviderProfile Model Fields
        public string ProfileId { get; set; }
        public string? ServicesOffered { get; set; }
        public string? Availability { get; set; }
        public decimal Rating { get; set; }  // Read-only (cannot be edited manually)

        public List<string> AvailabilityOptions { get; set; }
        public List<ServiceType> ServiceOptions { get; set; }
    }
}
