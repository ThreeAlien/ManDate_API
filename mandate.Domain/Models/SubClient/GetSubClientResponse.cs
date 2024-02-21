using AutoMapper;
using mandate.Business.Models;
using mandate.Domain.Po;
using mandate.Helper.Mapper;

namespace mandate.Domain.Models.SubClient;

/// <summary>
/// 取得子帳戶基本資料 Response
/// </summary>
public class GetSubClientResponse : BaseResponse<List<GetSubClientInfo>>
{
}

/// <summary>
/// 取得子帳戶內容
/// </summary>
public class GetSubClientInfo : IMapFrom<SysSubClientPo>
{
    /// <summary>
    /// 子帳戶ID
    /// </summary>
    public string? SubId { get; set; }

    /// <summary>
    /// 子帳戶名稱
    /// </summary>
    public string? SubName { get; set; }

    /// <summary>
    /// 客戶ID
    /// </summary>
    public string? ClientId { get; set; }

    void IMapFrom<SysSubClientPo>.Mapping(Profile profile)
    {
        profile.CreateMap<SysSubClientPo, GetSubClientInfo>()
            .ForMember(d => d.SubId, map => map.MapFrom(s => s.SubId))
            .ForMember(d => d.SubName, map => map.MapFrom(s => s.SubName))
            .ForMember(d => d.ClientId, map => map.MapFrom(s => s.ClientId));
    }
}