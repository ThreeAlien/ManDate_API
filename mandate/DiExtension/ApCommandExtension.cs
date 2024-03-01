using mandate.Application.AdsData;
using mandate.Application.Auth;
using mandate.Application.CustomerInfo;
using mandate.Application.InsertAdsData;
using mandate.Application.ReportContentInfo;
using mandate.Application.ReportInfo;
using mandate.Application.Sso;
using mandate.Application.SubClient;
using mandate.Business.Service;
using mandate.Domain.Models;
using mandate.Domain.Models.AdsData;
using mandate.Domain.Models.Customer;
using mandate.Domain.Models.ReportContent;
using mandate.Domain.Models.Sso;
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
        service.AddScoped<IRequestHandler<GetReportDefaultFieldsRequest, GetReportDefaultFieldsResponse>, GetReportDefaultFieldsCommandHandler>();

        service.AddScoped<IRequestHandler<GetReportRequest, GetReportResponse>, GetReportCommandHandler>();
        service.AddScoped<IRequestHandler<CreateReportRequest, CreateReportResponse>, CreateReportCommandHandler>();
        service.AddScoped<IRequestHandler<UpdateReportRequest, UpdateReportResponse>, UpdateReportCommandHandler>();
        service.AddScoped<IRequestHandler<DeleteReportRequest, DeleteReportResponse>, DeleteReportCommandHandler>();

        service.AddScoped<IRequestHandler<AuthenlizationRequest, AuthenlizationResponse>, AuthenlizationCommandHandler>();

        service.AddScoped<IRequestHandler<GetSubClientRequest, GetSubClientResponse>, GetSubClientCommandHandler>();
        service.AddScoped<IRequestHandler<AddCustomerRequest, AddCustomerResponse>, AddCustomerCommandHandler>();
        service.AddScoped<IRequestHandler<GetSysAdsDataRequest, GetSysAdsDataResponse>, GetSysAdsDataCommandHandler>();
        service.AddScoped<IRequestHandler<GetAdsAccountRequest, GetAdsAccountResponse>, GetAdsAccountCommandHandler>();

        
        service.AddScoped<IRequestHandler<AuthorizeCallBackRequest, AuthorizeCallBackResponse>, AuthorizeCallBackCommandHandler>();
        #region Ads 資料導入
        service.AddScoped<IRequestHandler<InsertSysAdsDataCampaignActionRequest, InsertSysAdsDataCampaignActionResponse>, InsertSysAdsDataCampaignActionCommandHandler>();
        service.AddScoped<IRequestHandler<InsertSysAdsDataAdGroupCriterionRequest, InsertSysAdsDataAdGroupCriterionResponse>, InsertSysAdsDataAdGroupCriterionCommandHandler>();
        service.AddScoped<IRequestHandler<InsertSysAdsDataCampaignConRequest, InsertSysAdsDataCampaignConResponse>, InsertSysAdsDataCampaignConCommandHandler>();
        service.AddScoped<IRequestHandler<InsertSysAdsDataCampaignLocationRequest, InsertSysAdsDataCampaignLocationResponse>, InsertSysAdsDataCampaignLocationCommandHandler>();
        service.AddScoped<IRequestHandler<InsertSysAdsDataCampaignRequest, InsertSysAdsDataCampaignResponse>, InsertSysAdsDataCampaignCommandHandler>();
        service.AddScoped<IRequestHandler<InsertSysAdsDataCampaignOtherRequest, InsertSysAdsDataCampaignOtherResponse>, InsertSysAdsDataCampaignOtherCommandHandler>();
        service.AddScoped<IRequestHandler<InsertSysAdsDataAdGroupAdRequest, InsertSysAdsDataAdGroupAdResponse>, InsertSysAdsDataAdGroupAdCommandHandler>();
        #endregion
        return service;
    }
}