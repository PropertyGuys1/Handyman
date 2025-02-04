namespace Handyman.Data.Entities
{
    public class Service
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Catagory { get; set; }

        public Decimal? Cost { get; set; }

        public bool IsDeleted { get; set; }


    }
}