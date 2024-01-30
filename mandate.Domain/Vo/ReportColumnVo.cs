using AutoMapper;
using mandate.Domain.Po;
using mandate.Helper.Mapper;

namespace mandate.Domain.Vo;

/// <summary>
/// 報表欄位 Vo
/// </summary>
public class ReportColumnVo : IMapTo<SysReportColumnPo>
{
    public bool? ColAccount { get; set; }
    public bool? ColCutomerID { get; set; }
    public bool? ColCampaignID { get; set; }
    public bool? ColAdGroupID { get; set; }
    public bool? ColAdFinalURL { get; set; }
    public bool? ColHeadline { get; set; }
    public bool? ColShortHeadLine { get; set; }
    public bool? ColLongHeadLine { get; set; }
    public bool? ColHeadLine_1 { get; set; }
    public bool? ColHeadLine_2 { get; set; }
    public bool? ColDirections { get; set; }
    public bool? ColDirections_1 { get; set; }
    public bool? ColDirections_2 { get; set; }
    public bool? ColAdName { get; set; }
    public bool? ColAdPath_1 { get; set; }
    public bool? ColAdPath_2 { get; set; }
    public bool? ColSrchKeyWord { get; set; }
    public bool? ColSwitchTarget { get; set; }
    public bool? ColDateTime { get; set; }
    public bool? ColWeek { get; set; }
    public bool? ColSeason { get; set; }
    public bool? ColMonth { get; set; }
    public bool? ColIncome { get; set; }
    public bool? ColTransTime { get; set; }
    public bool? ColTransCostOnce { get; set; }
    public bool? ColTrans { get; set; }
    public bool? ColTransRate { get; set; }
    public bool? ColClick { get; set; }
    public bool? ColImpression { get; set; }
    public bool? ColCTR { get; set; }
    public bool? ColCPC { get; set; }
    public bool? ColCost { get; set; }
    public string ContentId { get; set; } = null!;

    public string ColumnId { get; set; } = null!;
    public bool? ColAge { get; set; }
    public bool? ColSex { get; set; }
    public bool? ColRegion { get; set; }

    void IMapTo<SysReportColumnPo>.Mapping(Profile profile)
    {
        profile.CreateMap<ReportColumnVo, SysReportColumnPo>()
            .ForMember(d => d.IsColAccount, map => map.MapFrom(s => s.ColAccount))
            .ForMember(d => d.IsColCutomerID, map => map.MapFrom(s => s.ColCutomerID))
            .ForMember(d => d.IsColCampaignID, map => map.MapFrom(s => s.ColCampaignID))
            .ForMember(d => d.IsColAdGroupID, map => map.MapFrom(s => s.ColAdGroupID))
            .ForMember(d => d.IsColAdFinalURL, map => map.MapFrom(s => s.ColAdFinalURL))
            .ForMember(d => d.IsColHeadline, map => map.MapFrom(s => s.ColHeadline))
            .ForMember(d => d.IsColShortHeadLine, map => map.MapFrom(s => s.ColShortHeadLine))
            .ForMember(d => d.IsColLongHeadLine, map => map.MapFrom(s => s.ColLongHeadLine))
            .ForMember(d => d.IsColHeadLine_1, map => map.MapFrom(s => s.ColHeadLine_1))
            .ForMember(d => d.IsColHeadLine_2, map => map.MapFrom(s => s.ColHeadLine_2))
            .ForMember(d => d.IsColDirections, map => map.MapFrom(s => s.ColDirections))
            .ForMember(d => d.IsColDirections_1, map => map.MapFrom(s => s.ColDirections_1))
            .ForMember(d => d.IsColDirections_2, map => map.MapFrom(s => s.ColDirections_2))
            .ForMember(d => d.IsColAdName, map => map.MapFrom(s => s.ColAdName))
            .ForMember(d => d.IsColAdPath_1, map => map.MapFrom(s => s.ColAdPath_1))
            .ForMember(d => d.IsColAdPath_2, map => map.MapFrom(s => s.ColAdPath_2))
            .ForMember(d => d.IsColSrchKeyWord, map => map.MapFrom(s => s.ColSrchKeyWord))
            .ForMember(d => d.IsColSwitchTarget, map => map.MapFrom(s => s.ColSwitchTarget))
            .ForMember(d => d.IsColDateTime, map => map.MapFrom(s => s.ColDateTime))
            .ForMember(d => d.IsColWeek, map => map.MapFrom(s => s.ColWeek))
            .ForMember(d => d.IsColSeason, map => map.MapFrom(s => s.ColSeason))
            .ForMember(d => d.IsColMonth, map => map.MapFrom(s => s.ColMonth))
            .ForMember(d => d.IsColIncome, map => map.MapFrom(s => s.ColIncome))
            .ForMember(d => d.IsColTransTime, map => map.MapFrom(s => s.ColTransTime))
            .ForMember(d => d.IsColTransCostOnce, map => map.MapFrom(s => s.ColTransCostOnce))
            .ForMember(d => d.IsColTrans, map => map.MapFrom(s => s.ColTrans))
            .ForMember(d => d.IsColTransRate, map => map.MapFrom(s => s.ColTransRate))
            .ForMember(d => d.IsColClick, map => map.MapFrom(s => s.ColClick))
            .ForMember(d => d.IsColImpression, map => map.MapFrom(s => s.ColImpression))
            .ForMember(d => d.IsColCTR, map => map.MapFrom(s => s.ColCTR))
            .ForMember(d => d.IsColCPC, map => map.MapFrom(s => s.ColCPC))
            .ForMember(d => d.IsColCost, map => map.MapFrom(s => s.ColCost))
            .ForMember(d => d.ContentId, map => map.MapFrom(s => s.ContentId))
            .ForMember(d => d.ColumnId, map => map.MapFrom(s => s.ColumnId))
            .ForMember(d => d.IsColAge, map => map.MapFrom(s => s.ColAge))
            .ForMember(d => d.IsColSex, map => map.MapFrom(s => s.ColSex))
            .ForMember(d => d.IsColRegion, map => map.MapFrom(s => s.ColRegion));
    }
}
