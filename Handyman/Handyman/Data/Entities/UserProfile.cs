using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Handyman.Data.Entities
{
    public class UserProfile
    {

        [Key]
        [Required]
        public string UserId { get; set; }
        public string? DisplayName { get; set; }
        [Required]
        public string? Email { get; set; }

        public string? Gender { get; set; }

        public DateOnly BirthOfDate { get; set; }

        public bool IsReceivePromotionalEmails { get; set; }
        public bool IsDeleted { get; set; }

        // Navigation property
        public ICollection<Address>? Addresses { get; set; }
        public ICollection<Service>? ServiceHistroy { get; set; }
        public ICollection<ServiceReview>? ServiceReviews { get; set; }

    }
}
