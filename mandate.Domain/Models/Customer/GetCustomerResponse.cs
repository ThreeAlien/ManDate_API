using AutoMapper;
using mandate.Business.Models;
using mandate.Domain.Po;
using mandate.Helper.Mapper;

namespace mandate.Domain.Models.Customer;

/// <summary>
/// 取得顧客資料 Response
/// </summary>
public class GetCustomerResponse : BaseResponse<List<GetCustInfo>>
{
}

/// <summary>
/// 取得顧客資料
/// </summary>
public class GetCustInfo : IMapFrom<SysClientPo>
{
    /// <summary>
    /// 顧客ID
    /// </summary>
    public string ClientId { get; set; } = null!;

    /// <summary>
    /// 顧客姓名
    /// </summary>
    public string? ClientName { get; set; }

    /// <summary>
    /// 顧客狀態
    /// </summary>
    public bool? ClientStatus { get; set; }

    void IMapFrom<SysClientPo>.Mapping(Profile profile)
    {
        profile.CreateMap<SysClientPo, GetCustInfo>()
            .ForMember(d => d.ClientId, map => map.MapFrom(s => s.ClientId))
            .ForMember(d => d.ClientName, map => map.MapFrom(s => s.ClientName))
            .ForMember(d => d.ClientStatus, map => map.MapFrom(s => s.ClientStatus));
    }
}