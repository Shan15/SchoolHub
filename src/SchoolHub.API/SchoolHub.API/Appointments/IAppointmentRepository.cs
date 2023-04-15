using System.Threading.Tasks;

namespace SchoolHub.API.Appointments
{
    public interface IAppointmentRepository
    {
        public Task<IEnumerable<AppointmentModel>> GetAll();
        public Task<AppointmentModel> GetById(string id);
        public Task<AppointmentModel> Create(AppointmentRequest appointment);
        public Task<AppointmentModel> Update(string id, AppointmentRequest appointment);
        public Task<bool> Delete(string id);
    }
}
