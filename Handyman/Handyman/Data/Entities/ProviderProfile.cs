namespace Handyman.Data.Entities
{
    public class ProviderProfile
    {
        public int Id { get; set; }
        public string ProfileId { get; set; }
        public string ServicesOffered { get; set; } // List of services provided
        public string Availability { get; set; } // Availability schedule
        public decimal Rating { get; set; } // Average rating
        public int Balance { get; set; } = 0;
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
        // Navigation property
        public virtual Profile Profile { get; set; }
        public virtual ICollection<ProviderService> ProviderServices { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<AppointmentFeedback> AppointmentFeedbacks { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
