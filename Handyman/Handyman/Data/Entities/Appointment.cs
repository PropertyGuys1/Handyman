namespace Handyman.Data.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string Address { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Status { get; set; }  // E.g., "Pending", "Confirmed", etc.
        public int ServiceId { get; set; }
        public Service Service { get; set; }  // Navigation property to Service
        public string UserId { get; set; }  // The user who booked the service
        
        public string notes { get; set; }

    }
}
