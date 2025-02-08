namespace Handyman.Data.Entities
{
    public class ProviderProfile
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string ServicesOffered { get; set; } // List of services provided
        public string Availability { get; set; } // Availability schedule
        public decimal Rating { get; set; } // Average rating

        // Navigation property
        public virtual Profile Profile { get; set; }
        public virtual ICollection<ProviderService> ProviderServices { get; set; }
    }
}
