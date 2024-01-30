using AutoMapper;
using mandate.Business.Models;
using mandate.Domain.Po;
using mandate.Helper.Mapper;

namespace mandate.Domain.Models.ReportContent;

/// <summary>
/// 取得報表預設欄位 Response
/// </summary>
public class GetReportDefaultFieldsResponse : BaseResponse<ReportDefaultFields>
{
}

/// <summary>
/// 報表預設欄位
/// </summary>
public class ReportDefaultFields : IMapFrom<SysReportColumnPo>
{
    public string ContentId { get; set; } = null!;

    public string ColumnId { get; set; } = null!;

    public bool? IsColAccount { get; set; }

    public bool? IsColCutomerID { get; set; }

    public bool? IsColCampaignID { get; set; }

    public bool? IsColAdGroupID { get; set; }

    public bool? IsColAdFinalURL { get; set; }

    public bool? IsColHeadline { get; set; }

    public bool? IsColShortHeadLine { get; set; }

    public bool? IsColLongHeadLine { get; set; }

    public bool? IsColHeadLine_1 { get; set; }

    public bool? IsColHeadLine_2 { get; set; }

    public bool? IsColDirections { get; set; }

    public bool? IsColDirections_1 { get; set; }

    public bool? IsColDirections_2 { get; set; }

    public bool? IsColAdName { get; set; }

    public bool? IsColAdPath_1 { get; set; }

    public bool? IsColAdPath_2 { get; set; }

    public bool? IsColSrchKeyWord { get; set; }

    public bool? IsColSwitchTarget { get; set; }

    public bool? IsColDateTime { get; set; }

    public bool? IsColWeek { get; set; }

    public bool? IsColSeason { get; set; }

    public bool? IsColMonth { get; set; }

    public bool? IsColIncome { get; set; }

    public bool? IsColTransTime { get; set; }

    public bool? IsColTransCostOnce { get; set; }

    public bool? IsColTrans { get; set; }

    public bool? IsColTransRate { get; set; }

    public bool? IsColClick { get; set; }

    public bool? IsColImpression { get; set; }

    public bool? IsColCTR { get; set; }

    public bool? IsColCPC { get; set; }

    public bool? IsColCost { get; set; }

    public bool? IsColAge { get; set; }

    public bool? IsColSex { get; set; }

    public bool? IsColRegion { get; set; }

    public string? ContentSort { get; set; } = null!;

    void IMapFrom<SysReportColumnPo>.Mapping(Profile profile)
    {
        profile.CreateMap<SysReportColumnPo, ReportDefaultFields>()
            .ForMember(d => d.ColumnId, map => map.MapFrom(s => s.ColumnId))
            .ForMember(d => d.IsColAccount, map => map.MapFrom(s => s.IsColAccount))
            .ForMember(d => d.IsColCutomerID, map => map.MapFrom(s => s.IsColCutomerID))
            .ForMember(d => d.IsColCampaignID, map => map.MapFrom(s => s.IsColCampaignID))
            .ForMember(d => d.IsColAdGroupID, map => map.MapFrom(s => s.IsColAdGroupID))
            .ForMember(d => d.IsColAdFinalURL, map => map.MapFrom(s => s.IsColAdFinalURL))
            .ForMember(d => d.IsColHeadline, map => map.MapFrom(s => s.IsColHeadline))
            .ForMember(d => d.IsColShortHeadLine, map => map.MapFrom(s => s.IsColShortHeadLine))
            .ForMember(d => d.IsColLongHeadLine, map => map.MapFrom(s => s.IsColLongHeadLine))
            .ForMember(d => d.IsColHeadLine_1, map => map.MapFrom(s => s.IsColHeadLine_1))
            .ForMember(d => d.IsColHeadLine_2, map => map.MapFrom(s => s.IsColHeadLine_2))
            .ForMember(d => d.IsColDirections, map => map.MapFrom(s => s.IsColDirections))
            .ForMember(d => d.IsColDirections_1, map => map.MapFrom(s => s.IsColDirections_1))
            .ForMember(d => d.IsColDirections_2, map => map.MapFrom(s => s.IsColDirections_2))
            .ForMember(d => d.IsColAdPath_1, map => map.MapFrom(s => s.IsColAdPath_1))
            .ForMember(d => d.IsColAdPath_2, map => map.MapFrom(s => s.IsColAdPath_2))
            .ForMember(d => d.IsColSrchKeyWord, map => map.MapFrom(s => s.IsColSrchKeyWord))
            .ForMember(d => d.IsColSwitchTarget, map => map.MapFrom(s => s.IsColSwitchTarget))
            .ForMember(d => d.IsColDateTime, map => map.MapFrom(s => s.IsColDateTime))
            .ForMember(d => d.IsColWeek, map => map.MapFrom(s => s.IsColWeek))
            .ForMember(d => d.IsColSeason, map => map.MapFrom(s => s.IsColSeason))
            .ForMember(d => d.IsColMonth, map => map.MapFrom(s => s.IsColMonth))
            .ForMember(d => d.IsColIncome, map => map.MapFrom(s => s.IsColIncome))
            .ForMember(d => d.IsColTransTime, map => map.MapFrom(s => s.IsColTransTime))
            .ForMember(d => d.IsColTransCostOnce, map => map.MapFrom(s => s.IsColTransCostOnce))
            .ForMember(d => d.IsColTrans, map => map.MapFrom(s => s.IsColTrans))
            .ForMember(d => d.IsColClick, map => map.MapFrom(s => s.IsColClick))
            .ForMember(d => d.IsColImpression, map => map.MapFrom(s => s.IsColImpression))
            .ForMember(d => d.IsColCTR, map => map.MapFrom(s => s.IsColCTR))
            .ForMember(d => d.IsColCPC, map => map.MapFrom(s => s.IsColCPC))
            .ForMember(d => d.IsColCost, map => map.MapFrom(s => s.IsColCost))
            .ForMember(d => d.ContentId, map => map.MapFrom(s => s.ContentId))
            .ForMember(d => d.IsColAge, map => map.MapFrom(s => s.IsColAge))
            .ForMember(d => d.IsColSex, map => map.MapFrom(s => s.IsColSex))
            .ForMember(d => d.IsColRegion, map => map.MapFrom(s => s.IsColRegion))
            .ForMember(d => d.ContentSort, map => map.MapFrom(s => s.ContentSort));
    }
}