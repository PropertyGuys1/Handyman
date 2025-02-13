using System.Drawing;

namespace Handyman.Data.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ServiceTypeId { get; set; }
        public string? Description {  get; set; }
        public int? Cost {  get; set; }
        public bool IsDeleted { get; set; }=false;
        // Navigation property
        public virtual ServiceType? ServiceType { get; set; }
        public virtual ICollection<ProviderService>? ProviderServices { get; set; }
    }
}