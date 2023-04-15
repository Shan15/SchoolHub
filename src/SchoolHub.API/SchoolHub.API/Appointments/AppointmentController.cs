using Microsoft.AspNetCore.Mvc;

namespace SchoolHub.API.Appointments
{
    [ApiController]
    [Route("appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _repository;
        
        public AppointmentController(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
       public async Task<ActionResult<AppointmentModel>> FindAll()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{appointmentId}")]
        public async Task<ActionResult<AppointmentModel>> FindById(string appointmentId)
        {
            var appointment = await _repository.GetById(appointmentId);
            if(appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentModel>> CreateAppointment(AppointmentRequest appointmentRequest)
        {
            var appointment = _repository.Create(appointmentRequest);
            return Ok(appointment);
        }

        [HttpPut("{appointmentId}")]
        public async Task<ActionResult<AppointmentModel>> EditAppointment(string appointmentId, AppointmentRequest appointmentRequest)
        {
            var appointment = await _repository.Update(appointmentId, appointmentRequest);
            if(appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpDelete("{appointmentId}")]
        public async Task<ActionResult<AppointmentModel>> DeleteAppointment(string appointmentId)
        {
            var wasDeleted = await _repository.Delete(appointmentId);
            if(!wasDeleted)
            {
                return NotFound();
            }
            return Ok(new { wasDeleted });
        }

    }
}
