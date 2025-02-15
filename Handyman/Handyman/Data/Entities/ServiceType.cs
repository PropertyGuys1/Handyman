namespace Handyman.Data.Entities
{
    public class ServiceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }=false;

        // Navigation property
        public virtual ICollection<Service>? Services { get; set; }
        public string? ImageUrl { get; set; }
    }
}
