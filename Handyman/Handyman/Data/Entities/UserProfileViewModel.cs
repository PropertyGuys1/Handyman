namespace Handyman.Data.Entities;

public class UserProfileViewModel
{
    public Profile Profile { get; set; }
    public CustomerProfile CustomerProfile { get; set; }
    public ProviderProfile ProviderProfile { get; set; }
    /*
    public Address Address { get; set; }
    */

    public decimal? Balance {  get; set; }
    
    public string Preferences { get; set; }
    public IEnumerable<Address> Addresses { get; set; } // Collection of addresses

    public IEnumerable<Appointment> Appointments { get; set; }
    public IEnumerable<AppointmentFeedback> Feedbacks { get; set; }
    public IEnumerable<Payment> Payments { get; set; }
}