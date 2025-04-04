using System;
using System.ComponentModel.DataAnnotations;

namespace Handyman.Data.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "User ID is required.")]
        public string? UserId { get; set; }

        [Required(ErrorMessage = "Cardholder name is required.")]
        [StringLength(50, ErrorMessage = "Cardholder name cannot exceed 50 characters.")]
        public string? CardHolderName { get; set; }

        [Required(ErrorMessage = "Card number is required.")]
        [CreditCard(ErrorMessage = "Invalid card number.")]
        [StringLength(16, MinimumLength = 13, ErrorMessage = "Card number must be between 13 and 16 digits.")]
        public string? CardNumber { get; set; }

        [Required(ErrorMessage = "Expiry date is required.")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Expiry date must be in MM/YY format.")]
        public string? ExpiryDate { get; set; }

        [Required(ErrorMessage = "CVV is required.")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "CVV must be 3 or 4 digits.")]
        public string? CVV { get; set; }
    }
}