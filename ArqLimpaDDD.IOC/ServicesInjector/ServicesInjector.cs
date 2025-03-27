using ArqLimpaDDD.Application.Interfaces.Users;
using ArqLimpaDDD.Application.Services.Books;
using ArqLimpaDDD.Application.Services.File;
using ArqLimpaDDD.Application.Services.Interfaces.Books;
using ArqLimpaDDD.Application.Services.Persons;
using ArqLimpaDDD.Application.Services.Token;
using ArqLimpaDDD.Application.Services.Users;
using ArqLimpaDDD.Domain.Interfaces.Repositories;
using ArqLimpaDDD.FrameWrkDrivers.Data.Context;
using ArqLimpaDDD.FrameWrkDrivers.Repositories;
using ArqLimpaDDD.FrameWrkDrivers.Repositories.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ArqLimpaDDD.IOC.ServicesInjector;

public static class ServicesInjector
{
    public static IServiceCollection AddServicesInjector(this IServiceCollection services)
    {
        services.AddScoped<DbSQLContext>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddScoped<IPersonService, PersonServiceImplementation>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookService, BookServiceImplementation>();
        services.AddScoped<IUserRepository, UserRepository>();
   //     services.AddScoped<ILoginService, LoginServiceImplementation>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IFileService, FileServiceImplementation>();

       // services.AddTransient<ITokenService, TokenService>();

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        return services;
    }
    public static IServiceCollection AddDbContextInjector(this IServiceCollection services, string connection)
    {
        services.AddDbContext<DbSQLContext>(options => options.UseSqlServer(connection));

        return services;
    }
}
