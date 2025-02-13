namespace Handyman.Data.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int ProviderServiceId { get; set; }
        public int CustomerProfileId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string CustomerNote { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public virtual ProviderService ProviderService { get; set; }
        public virtual CustomerProfile CustomerProfile { get; set;}

        public virtual AppointmentFeedback AppointmentFeedback { get; set; }
        public virtual Payment Payment { get; set; }


    }
}
