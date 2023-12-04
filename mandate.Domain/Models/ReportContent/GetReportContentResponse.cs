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
/// 取得報表內容
/// </summary>
public class GetReportContentInfo : IMapFrom<SysReportContentPo>
{
    /// <summary>
    /// 報表內容ID
    /// </summary>
    public string ContentID { get; set; } = null!;

    /// <summary>
    /// 報表內容名稱
    /// </summary>
    public string ContentName { get; set; } = null!;

    void IMapFrom<SysReportContentPo>.Mapping(Profile profile)
    {
        profile.CreateMap<SysReportContentPo, GetReportContentInfo>()
            .ForMember(d => d.ContentID, map => map.MapFrom(s => s.ContentID))
            .ForMember(d => d.ContentName, map => map.MapFrom(s => s.ContentName));
    }
}