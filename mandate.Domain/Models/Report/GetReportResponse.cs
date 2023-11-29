using AutoMapper;
using mandate.Domain.Po;
using mandate.Helper.Mapper;

namespace mandate.Domain.Models;

/// <summary>
/// 取得顧客資料 Response
/// </summary>
public class GetReportResponse
{
    public string? Code { get; set; }

    public List<GetReportInfo>? Data { get; set; }

    public string? Msg { get; set; }

}

/// <summary>
/// 取得顧客資料
/// </summary>
public class GetReportInfo : IMapFrom<SysReportPo>
{
    /// <summary>
    /// 顧客ID
    /// </summary>
    public string ReportNo { get; set; } = null!;

    /// <summary>
    /// 顧客姓名
    /// </summary>
    public string? ReportName { get; set; }

    void IMapFrom<SysReportPo>.Mapping(Profile profile)
    {
        profile.CreateMap<SysReportPo, GetReportInfo>()
            .ForMember(d => d.ReportNo, map => map.MapFrom(s => s.ReportNo))
            .ForMember(d => d.ReportName, map => map.MapFrom(s => s.ReportName));
    }
}