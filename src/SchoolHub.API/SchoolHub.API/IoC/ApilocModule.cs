namespace SchoolHub.API.IoC;

public class ApilocModule
{
    public static void Dependencies(IServiceCollection service)
    {
        service.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
    }
}