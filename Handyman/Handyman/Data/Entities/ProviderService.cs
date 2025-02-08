namespace Handyman.Data.Entities
{
    public class ProviderService
    {
        public int Id { get; set; }
        public int ProviderProfileId { get; set; }
        public int ServiceId { get; set; }
        public string Notes { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public virtual ProviderProfile ProviderProfile { get; set; }
        public virtual Service Service { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
