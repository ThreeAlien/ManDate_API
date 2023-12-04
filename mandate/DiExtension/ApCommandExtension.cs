using mandate.Application.Auth;
using mandate.Application.CustomerInfo;
using mandate.Application.ReportContentInfo;
using mandate.Application.ReportInfo;
using mandate.Application.SubClient;
using mandate.Business.Service;
using mandate.Domain.Models;
using mandate.Domain.Models.Customer;
using mandate.Domain.Models.ReportContent;
using mandate.Domain.Models.SubClient;
using MediatR;
using System.Reflection;

namespace mandate.api.DiExtension;

public static class ApCommandExtension
{
    public static IServiceCollection AddApCommands(this IServiceCollection service)
    {
        service.AddMediatR(cf => cf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        service.AddScoped<IGoogleAdsService, GoogleAdsService>();

        service.AddScoped<IRequestHandler<GetCustomerRequest, GetCustomerResponse>, GetCustomerCommandHandler>();

        service.AddScoped<IRequestHandler<GetReportContentRequest, GetReportContentResponse>, GetReportContentCommandHandler>();

        service.AddScoped<IRequestHandler<GetReportRequest, GetReportResponse>, GetReportCommandHandler>();
        service.AddScoped<IRequestHandler<CreateReportRequest, CreateReportResponse>, CreateReportCommandHandler>();

        service.AddScoped<IRequestHandler<AuthenlizationRequest, AuthenlizationResponse>, AuthenlizationCommandHandler>();

        service.AddScoped<IRequestHandler<GetSubClientRequest, GetSubClientResponse>, GetSubClientCommandHandler>();

        return service;
    }
}