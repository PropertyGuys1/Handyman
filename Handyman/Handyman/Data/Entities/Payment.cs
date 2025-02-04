namespace Handyman.Data.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public string CustomerId { get; set; }

        public Guid AppointmentId { get; set; }

        public decimal Amount { get; set; }
        public string Method { get; set; }
        public string? Status {  get; set; }

        public string? Invoice {  get; set; }

        public bool IsDeleted { get; set; }

    }
}
