namespace Handyman.Data.Entities;


public class ServiceDetailsViewModel
{
    public Service? Service { get; set; }
    public CustomerProfile? User { get; set; }
    
    public IEnumerable<Address>? Addresses { get; set; } // Collection of addresses
    public IEnumerable<Payment>? Payments { get; set; } // Collection of payments
}
