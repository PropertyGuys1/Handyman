using System.ComponentModel.DataAnnotations;

namespace Handyman.Data.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string userId { get; set; }
        
        [Required(ErrorMessage = "Street address is required.")]
        public string? Street { get; set; }
        
        [Required(ErrorMessage = "City is required.")]
        public string? City { get; set; }
        public string? State { get; set; }
        
        [Required(ErrorMessage = "Postal code is required.")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$", ErrorMessage = "Postal code must be in the format A1A 1A1.")]
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
