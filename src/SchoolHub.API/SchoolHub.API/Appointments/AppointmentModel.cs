using SchoolHub.API.Users;

namespace SchoolHub.API.Appointments
{
    public class AppointmentModel
    {
        public string Id { get; set; }
        public string Appointment { get; set; }
        public string Description { get; set; }
        public DateTime From { get; set;}
        public DateTime To { get; set;}
        public UserModel User { get; set; }

    }
}
