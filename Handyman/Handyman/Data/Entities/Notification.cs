namespace Handyman.Data.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }

        public string CustomerId { get; set; }

        public string ProviderId { get; set; }

        public string? Message { get; set; }

        public string? Type { get; set; }

        public DateTime? CreatedDateTime { get; set; }
     
    }
}
