using Dapper;
using SchoolHub.API.IoC;
using SchoolHub.API.Users;

namespace SchoolHub.API.Appointments
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DapperContext _context;

        public AppointmentRepository(DapperContext context)
        {
            _context = context;
        }
        public async void Create(AppointmentModel appointment, UserModel user)
        {
            var connection = _context.Connection;
            _ = await connection.ExecuteAsync("INSERT INTO Appointment VALUES " +
                "(@appointment, @from, @to, @userId)", new
            {
                appointment.Appointment,
                appointment.From,
                appointment.To,
                userId = user.Id
            });
        }

        public async void Delete(string id)
        {
            var connection = _context.Connection;
            _ = await connection.ExecuteAsync("DELETE FROM Appointment WHERE id=@id", new { id });
        }

        public async Task<IEnumerable<AppointmentModel>> GetAll(string userId)
        {
            var connection = _context.Connection;
            var appointments = await connection.QueryAsync<AppointmentModel>("SELECT * FROM Appointment AS a INNER JOIN User AS u ON u.id = a.userId WHERE u.id = @id", new { userId });
            return appointments.ToList();
        }

        public async Task<AppointmentModel> GetById(string id)
        {
            var connection = _context.Connection;
            var appointment = await connection.QueryAsync<AppointmentModel>("SELECT * FROM Appointment AS a INNER JOIN User AS u ON u.id = a.userId WHERE a.id = @id", new { id });
            return appointment.First();

        }

        public Task<AppointmentModel> Update(string id, AppointmentModel appointment)
        {
            var connection = _context.Connection;
            _ = connection.ExecuteAsync("UPDATE Appointment SET appointment=@appointment, description=@description, from=@from, to=@to WHERE id=@id", 
            new {
                appointment.Appointment,
                appointment.Description,
                appointment.From,
                appointment.To,
            }) ;
            return Task.FromResult(appointment);
        }
    }
}
