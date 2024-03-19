using AutoMapper;
using mandate.Business.Service;
using mandate.Domain.Models.Auth;
using mandate.Domain.Models.Customer;
using mandate.Domain.Po;
using mandate.Domain.Vo;
using mandate.Infrastructure;
using mandate.Utility.Crypto;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace mandate.Application.Auth;

public class GetAccessRoleCommandHandler : IRequestHandler<GetAccessRoleRequest, GetAccessRoleResponse>
{
    /// <summary>
    /// mapper
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Config設定檔
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Google Ads服務
    /// </summary>
    private readonly IGoogleAdsService _googleAdsService;

    /// <summary>
    /// 建構子
    /// </summary>
    public GetAccessRoleCommandHandler(IMapper mapper, IConfiguration configuration, IGoogleAdsService googleAdsService)
    {
        _mapper = mapper;
        _configuration = configuration;
        _googleAdsService = googleAdsService;
    }

    public async Task<GetAccessRoleResponse> Handle(GetAccessRoleRequest request, CancellationToken cancellationToken)
    {
        GetAccessRoleResponse response = new();
        try
        {
            if (string.IsNullOrEmpty(request.CustId))
            {
                return response = new()
                {
                    Code = "404",
                    Data = null,
                    Msg = "MCC帳戶為必填"
                };
            }

            string? refreshToken = await _googleAdsService.GenerateRefreshToken();
            List<Business.Models.GetAccessRoleResult> accessRoleResults = _googleAdsService.AccessRole(refreshToken, request.CustId);

            response = new()
            {
                Data = _mapper.Map<List<GetAccessRoleVo>>(accessRoleResults)
            };
        }
        catch (Exception ex)
        {
            response = new()
            {
                Code = "500",
                Data = null,
                Msg = ex.Message
            };
        }
        return response;
    }
}
