﻿using SchoolHub.API.School;

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
        service.AddScoped<ISchoolRepository, SchoolRespository>();
        service.AddControllers();
    }
}

public interface IApiModule
{
    void RegisterDependencies(IServiceCollection service);
}