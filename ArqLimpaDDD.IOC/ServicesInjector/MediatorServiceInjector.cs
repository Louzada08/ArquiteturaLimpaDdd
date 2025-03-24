using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ArqLimpaDDD.Application.Commands.Users.Requests;
using ArqLimpaDDD.Application.Commands.Users;
using ArqLimpaDDD.Domain.Mediator.Interfaces;
using ArqLimpaDDD.Domain.Mediator;
using ArqLimpaDDD.Domain.Validation;
using ArqLimpaDDD.Application.Commands.Persons.Requests;
using ArqLimpaDDD.Application.Commands.Persons.Handlers;

namespace ArqLimpaDDD.IOC.ServicesInjector;

public static class MediatorServiceInjector
{
    public static IServiceCollection AddMediatorInjector(this IServiceCollection services)
    {
        services.AddScoped<IMediatorHandler, MediatorHandler>();

        services.AddScoped<IRequestHandler<CreateUserRequest, ValidationResultBag>, UserCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateUserRequest, ValidationResultBag>, UserCommandHandler>();
        services.AddScoped<IRequestHandler<PatchUserRequest, ValidationResultBag>, UserCommandHandler>();
        services.AddScoped<IRequestHandler<DeleteUserRequest, ValidationResultBag>, UserCommandHandler>();

        services.AddScoped<IRequestHandler<CreatePersonRequest, ValidationResultBag>, PersonCommandHandler>();

        return services;
    }
}
