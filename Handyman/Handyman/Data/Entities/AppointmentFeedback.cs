namespace Handyman.Data.Entities
{
    public class AppointmentFeedback
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int CustomerProfileId { get; set; }
        public string Feedback { get; set; }
        public int Rating { get; set; } // Rating out of 5
        public bool IsApproved { get; set; } // Indicates if the feedback is approved by admin
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public virtual Appointment Appointment { get; set; }
        public virtual CustomerProfile CustomerProfile { get; set; }
    }
}
