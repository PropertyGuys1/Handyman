namespace Handyman.Data.Entities;

public class UserProfileViewModel
{
    public Profile Profile { get; set; }
    public CustomerProfile CustomerProfile { get; set; }
    public Address Address { get; set; }
    public IEnumerable<Appointment> Appointments { get; set; }
    public IEnumerable<AppointmentFeedback> Feedbacks { get; set; }
    public IEnumerable<Payment> Payments { get; set; }
}