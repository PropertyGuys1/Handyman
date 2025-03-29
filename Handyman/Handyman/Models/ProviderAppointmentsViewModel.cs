using Handyman.Data.Entities;

namespace Handyman.Models
{
    public class ProviderAppointmentsViewModel
    {
        public List<Appointment> UpcomingAppointments { get; set; }
        public List<Appointment> InProgressAppointments { get; set; }
        public List<Appointment> CompletedAppointments { get; set; }
    }

}
