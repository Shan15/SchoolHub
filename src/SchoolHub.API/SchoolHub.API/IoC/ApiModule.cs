using SchoolHub.API.Appointments;

namespace SchoolHub.API.IoC;

public class ApiModule : IApiModule
{
    private static string _connectionString;

    public ApiModule(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void RegisterDependencies(IServiceCollection service)
    {
        service.AddSingleton<DapperContext>(_ => new DapperContext(_connectionString));
        service.AddScoped<IAppointmentRepository, AppointmentRepository>();
        service.AddControllers();
    }
}

public interface IApiModule
{
    void RegisterDependencies(IServiceCollection service);
}