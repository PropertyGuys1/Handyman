namespace Handyman.Data.Entities
{
    public class ServiceReview
    {
        public Guid Id { get; set; }
        public string CustomerId { get; set; }
        public string ProviderId { get; set; }
        public decimal Rating { get; set; }

        public string? Feedback { get; set; }

        public DateTime? Created { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsApproved { get; set; }
    }
}
