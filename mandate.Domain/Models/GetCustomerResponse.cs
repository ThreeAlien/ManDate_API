using AutoMapper;
using mandate.Domain.Po;
using mandate.Helper.Mapper;

namespace mandate.Domain.Models;

/// <summary>
/// 取得顧客資料 Response
/// </summary>
public class GetCustomerResponse
{
    public string? Code { get; set; }

    public List<GetCustInfo>? Data { get; set; }

    public string? Msg { get; set; }
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

    void IMapFrom<SysClientPo>.Mapping(Profile profile)
    {
        profile.CreateMap<SysClientPo, GetCustInfo>()
            .ForMember(d => d.ClientId, map => map.MapFrom(s => s.client_id))
            .ForMember(d => d.ClientName, map => map.MapFrom(s => s.client_name));
    }
}