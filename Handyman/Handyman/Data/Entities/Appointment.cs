namespace Handyman.Data.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public string CustomerId {  get; set; }

        public Guid ServiceId { get; set; }

        public DateTime ServiceDateTime { get; set; }

        public string? Status { get; set; }

        public bool Urgent { get; set; } = false;

        public string Location { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set;} = DateTime.Now;


    }
}
