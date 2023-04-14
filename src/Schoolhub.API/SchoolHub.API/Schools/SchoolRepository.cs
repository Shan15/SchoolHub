using Dapper;
using SchoolHub.API.IoC;

namespace SchoolHub.API.Schools
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly DapperContext _context;
        public SchoolRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SchoolModel>> GetAll()
        {
            var connection = _context.Connection;
            var schools = await connection.QueryAsync<SchoolModel>("SELECT * FROM School");
            return schools.ToList();
        }

        public async Task<IEnumerable<SchoolModel>> GetByUser(string userId)
        {
            var connection = _context.Connection;
            var schools = await connection.QueryAsync<SchoolModel>("SELECT * FROM School AS s INNER JOIN SchoolUser AS su ON su.schoolId = s.id INNER JOIN User AS u ON su.userId = u.id WHERE u.id = @userId", new { userId });
            return schools.ToList();
        }

        public async Task<SchoolModel> GetById(string id)
        {
            var connection = _context.Connection;
            var school = await connection.QueryAsync<SchoolModel>("SELECT * FROM School WHERE id=@id", new { id });
            return school.First();
        }

        public async void CreateSchoolUserLink(string userId, string schoolId)
        {
            var connection = _context.Connection;
            await connection.ExecuteAsync("INSERT INTO SchoolUser(userId, schoolId) VALUES(@userId, @schoolId)", new { userId, schoolId });
            
        }

        public async void DeleteSchoolUserLink(string userId, string schoolId)
        {
            var connection = _context.Connection;
            await connection.ExecuteAsync("DELETE FROM SchoolUser WHERE userId=@userId and schoolId=@schoolId", new { userId, schoolId });
        }
    }
}
