

using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace SchoolHub.API.Schools
{
    [ApiController]
    [Route("api/schools")]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        [HttpGet]
        public async Task<ActionResult> FindAll()
        {
            return Ok(await _schoolRepository.GetAll());
        }

        [HttpGet("{schoolId}")]
        public async Task<ActionResult> FindById(string schoolId)
        {
            var school = await _schoolRepository.GetById(schoolId);
            if(school == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        [HttpGet("users")]
        public async Task<ActionResult> FindByUser(string userId)
        {
            return Ok(await _schoolRepository.GetByUser("1234"));

        }

        [HttpPost("{schoolId}")]
        public async Task<ActionResult> AddSchoolToUser(string userId, string schoolId)
        {
            var uri = Request.GetDisplayUrl();
            _schoolRepository.CreateSchoolUserLink(userId, schoolId);
            return Created(uri, new { worked = true });
        }

        [HttpDelete("{schoolId}")]
        public async Task<ActionResult> RemoveSchoolFromUser(string userId, string schoolId)
        {
            _schoolRepository.DeleteSchoolUserLink(userId, schoolId);
            return Ok(new { worked = true });
        }
        
    }
}
