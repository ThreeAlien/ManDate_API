using AutoMapper;
using mandate.Domain.Po;
using mandate.Helper.Mapper;

namespace mandate.Domain.Models.ReportContent;

/// <summary>
/// 取得顧客資料 Response
/// </summary>
public class GetReportContentResponse
{
    public string? Code { get; set; }

    public List<GetReportContentInfo>? Data { get; set; }

    public string? Msg { get; set; }

}

/// <summary>
/// 取得顧客資料
/// </summary>
public class GetReportContentInfo : IMapFrom<SysReportContentPo>
{
    /// <summary>
    /// 顧客ID
    /// </summary>
    public string ContentNo { get; set; } = null!;

    /// <summary>
    /// 顧客姓名
    /// </summary>
    public string? ContentName { get; set; }

    void IMapFrom<SysReportContentPo>.Mapping(Profile profile)
    {
        profile.CreateMap<SysReportContentPo, GetReportContentInfo>()
            .ForMember(d => d.ContentNo, map => map.MapFrom(s => s.ContentNo))
            .ForMember(d => d.ContentName, map => map.MapFrom(s => s.ContentName));
    }
}