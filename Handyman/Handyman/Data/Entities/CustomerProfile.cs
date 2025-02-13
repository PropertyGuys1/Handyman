namespace Handyman.Data.Entities
{
    public class CustomerProfile
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string Preferences { get; set; } // Any specific preferences for the customer
        public int AddressId { get; set; }

        // Navigation property
        public virtual Profile Profile { get; set; }
        
        public IEnumerable<Address> Addresses { get; set; } // Collection of addresses
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<AppointmentFeedback> AppointmentFeedbacks { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }  
    }
}
