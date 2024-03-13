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
    public string ReportID { get; set; } = null!;

    /// <summary>
    /// 報表名稱
    /// </summary>
    public string ReportName { get; set; } = null!;

    /// <summary>
    /// 子帳戶名稱
    /// </summary>
    public string? SubClientName { get; set; }

    /// <summary>
    /// 報表目標
    /// </summary>
    public string? ReportGoalAds { get; set; }

    /// <summary>
    /// 報表媒體
    /// </summary>
    public string ReportMedia { get; set; } = null!;

    /// <summary>
    /// 報表內容ID(Join)
    /// </summary>
    public string? ColumnID { get; set; }

    /// <summary>
    /// 子帳戶UD
    /// </summary>
    public string SubID { get; set; } = null!;

    /// <summary>
    /// 編輯者
    /// </summary>
    public string? Editer { get; set; }

    /// <summary>
    /// 編輯日期
    /// </summary>
    public DateTime? EditDate { get; set; }

    /// <summary>
    /// 建立者
    /// </summary>
    public string? Creater { get; set; }
    /// <summary>
    /// 建立日期
    /// </summary>
    public DateTime? CreateDate { get; set; }
    /// <summary>
    /// 報表是否使用
    /// </summary>
    public bool? ReportStatus { get; set; }

    void IMapFrom<SysReportPo>.Mapping(Profile profile)
    {
        profile.CreateMap<SysReportPo, GetReportInfo>()
            .ForMember(d => d.ReportID, map => map.MapFrom(s => s.ReportID))
            .ForMember(d => d.ReportName, map => map.MapFrom(s => s.ReportName))
            .ForMember(d => d.SubClientName, map => map.Ignore())
            .ForMember(d => d.ReportGoalAds, map => map.MapFrom(s => s.ReportGoalAds))
            .ForMember(d => d.ReportMedia, map => map.MapFrom(s => s.ReportMedia))
            .ForMember(d => d.ColumnID, map => map.MapFrom(s => s.ColumnID))
            .ForMember(d => d.SubID, map => map.MapFrom(s => s.SubID))
            .ForMember(d => d.Editer, map => map.MapFrom(s => s.Editer))
            .ForMember(d => d.EditDate, map => map.MapFrom(s => s.EditDate))
            .ForMember(d => d.Creater, map => map.MapFrom(s => s.Creater))
            .ForMember(d => d.CreateDate, map => map.MapFrom(s => s.CreateDate))
            .ForMember(d => d.ReportStatus, map => map.MapFrom(s => s.ReportStatus));
    }
}