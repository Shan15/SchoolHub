namespace SchoolHub.API.Appointments
{
    public interface IAppointmentRepository
    {
        public Task<IEnumerable<AppointmentModel>> GetAll(string userId);
        public Task<AppointmentModel> GetById(string id);
        public void Create(AppointmentModel appointment);
        public Task<AppointmentModel> Update(string id, AppointmentModel appointment);
        public void Delete(string id);
    }
}
