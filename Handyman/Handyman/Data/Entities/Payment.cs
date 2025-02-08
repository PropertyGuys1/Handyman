namespace Handyman.Data.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int CustomerProfileId { get; set; }
        public int AppointmentId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // e.g., Credit Card, PayPal, etc.
        public DateTime PaymentDate { get; set; }
        public bool IsSuccessful { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public virtual CustomerProfile CustomerProfile { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
