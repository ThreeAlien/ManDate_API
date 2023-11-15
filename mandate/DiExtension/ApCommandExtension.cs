using mandate.Application.Auth;
using mandate.Application.CustomerInfo;
using mandate.Domain.Models;
using MediatR;
using System.Reflection;

namespace mandate.api.DiExtension;

public static class ApCommandExtension
{
    public static IServiceCollection AddApCommands(this IServiceCollection service)
    {
        service.AddMediatR(cf => cf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        service.AddScoped<IRequestHandler<GetCustomerRequest, GetCustomerResponse>, GetCustomerCommandHandler>();

        service.AddScoped<IRequestHandler<AuthenlizationRequest, AuthenlizationResponse>, AuthenlizationCommandHandler>();

        return service;
    }
}