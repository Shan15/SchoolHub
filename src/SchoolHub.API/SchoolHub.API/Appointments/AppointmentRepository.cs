using Dapper;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.OpenApi.Validations;
using SchoolHub.API.IoC;
using SchoolHub.API.Users;
using System;

namespace SchoolHub.API.Appointments
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DapperContext _context;

        public AppointmentRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<AppointmentModel> Create(AppointmentRequest appointment)
        {
            var guid = Guid.NewGuid();
            return await Create(guid.ToString(), appointment);
        }

        private async Task<AppointmentModel> Create(string id, AppointmentRequest appointment)
        {
            var connection = _context.Connection;
            _ = await connection.ExecuteAsync("INSERT INTO Appointment VALUES(@id, @appointment, @description, @from, @to, '1234')", new
            {
                id,
                appointment.Appointment,
                appointment.Description,
                appointment.From,
                appointment.To
            });

            return await this.GetById(id);
        }

        public async Task<bool> Delete(string id)
        {
            var connection = _context.Connection;
            var rows = await connection.ExecuteAsync("DELETE FROM Appointment WHERE id=@id", new { id });
            return rows > 0;
        }

        public async Task<IEnumerable<AppointmentModel>> GetAll()
        {
            var connection = _context.Connection;
            var appointments = await connection.QueryAsync<AppointmentModel, UserModel, AppointmentModel>("SELECT * FROM Appointment AS appointment INNER JOIN User AS user ON user.id = appointment.userId", (Appointment, User) =>
            {
                Appointment.User = User;
                return Appointment;
            });
            return appointments.ToList();
        }

        public async Task<AppointmentModel> GetById(string id)
        {
            var connection = _context.Connection;
            var appointment = await connection.QueryAsync<AppointmentModel, UserModel, AppointmentModel>("SELECT * FROM Appointment AS a INNER JOIN User AS u ON u.id = a.userId WHERE a.id = @id", (Appointment, User) =>
            {
                Appointment.User = User;
                return Appointment;
            }, new { id });
            return appointment.First();

        }

        public async Task<AppointmentModel> Update(string id, AppointmentRequest appointment)
        {
            var connection = _context.Connection;
            var deleted = await this.Delete(id);
            if (!deleted)
            {
                return null;
            }

            return await this.Create(id, appointment);
        }
    }
}
