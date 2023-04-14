namespace SchoolHub.API.Schools
{
    public interface ISchoolRepository
    {
        public Task<IEnumerable<SchoolModel>> GetAll();
        public Task<IEnumerable<SchoolModel>> GetByUser(string userId);
        public Task<SchoolModel> GetById(string id);
        public void CreateSchoolUserLink(string userId, string schoolId);
        public void DeleteSchoolUserLink(string userId, string schoolId);
    }
}
