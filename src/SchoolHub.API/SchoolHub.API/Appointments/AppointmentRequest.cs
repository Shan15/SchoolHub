namespace SchoolHub.API.Appointments
{
    public class AppointmentRequest
    {
        public string Appointment { get; set; }
        public string Description { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
