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
            .ForMember(d => d.ColAccount, map => map.MapFrom(s => s.ColAccount))
            .ForMember(d => d.ColCutomerID, map => map.MapFrom(s => s.ColCutomerID))
            .ForMember(d => d.ColCampaignID, map => map.MapFrom(s => s.ColCampaignID))
            .ForMember(d => d.ColAdGroupID, map => map.MapFrom(s => s.ColAdGroupID))
            .ForMember(d => d.ColAdFinalURL, map => map.MapFrom(s => s.ColAdFinalURL))
            .ForMember(d => d.ColHeadline, map => map.MapFrom(s => s.ColHeadline))
            .ForMember(d => d.ColShortHeadLine, map => map.MapFrom(s => s.ColShortHeadLine))
            .ForMember(d => d.ColLongHeadLine, map => map.MapFrom(s => s.ColLongHeadLine))
            .ForMember(d => d.ColHeadLine_1, map => map.MapFrom(s => s.ColHeadLine_1))
            .ForMember(d => d.ColHeadLine_2, map => map.MapFrom(s => s.ColHeadLine_2))
            .ForMember(d => d.ColDirections, map => map.MapFrom(s => s.ColDirections))
            .ForMember(d => d.ColDirections_1, map => map.MapFrom(s => s.ColDirections_1))
            .ForMember(d => d.ColDirections_2, map => map.MapFrom(s => s.ColDirections_2))
            .ForMember(d => d.ColAdName, map => map.MapFrom(s => s.ColAdName))
            .ForMember(d => d.ColAdPath_1, map => map.MapFrom(s => s.ColAdPath_1))
            .ForMember(d => d.ColAdPath_2, map => map.MapFrom(s => s.ColAdPath_2))
            .ForMember(d => d.ColSrchKeyWord, map => map.MapFrom(s => s.ColSrchKeyWord))
            .ForMember(d => d.ColSwitchTarget, map => map.MapFrom(s => s.ColSwitchTarget))
            .ForMember(d => d.ColDateTime, map => map.MapFrom(s => s.ColDateTime))
            .ForMember(d => d.ColWeek, map => map.MapFrom(s => s.ColWeek))
            .ForMember(d => d.ColSeason, map => map.MapFrom(s => s.ColSeason))
            .ForMember(d => d.ColMonth, map => map.MapFrom(s => s.ColMonth))
            .ForMember(d => d.ColIncome, map => map.MapFrom(s => s.ColIncome))
            .ForMember(d => d.ColTransTime, map => map.MapFrom(s => s.ColTransTime))
            .ForMember(d => d.ColTransCostOnce, map => map.MapFrom(s => s.ColTransCostOnce))
            .ForMember(d => d.ColTrans, map => map.MapFrom(s => s.ColTrans))
            .ForMember(d => d.ColTransRate, map => map.MapFrom(s => s.ColTransRate))
            .ForMember(d => d.ColClick, map => map.MapFrom(s => s.ColClick))
            .ForMember(d => d.ColImpression, map => map.MapFrom(s => s.ColImpression))
            .ForMember(d => d.ColCTR, map => map.MapFrom(s => s.ColCTR))
            .ForMember(d => d.ColCPC, map => map.MapFrom(s => s.ColCPC))
            .ForMember(d => d.ColCost, map => map.MapFrom(s => s.ColCost))
            .ForMember(d => d.ContentId, map => map.MapFrom(s => s.ContentId))
            .ForMember(d => d.ColumnId, map => map.MapFrom(s => s.ColumnId))
            .ForMember(d => d.ColAge, map => map.MapFrom(s => s.ColAge))
            .ForMember(d => d.ColSex, map => map.MapFrom(s => s.ColSex))
            .ForMember(d => d.ColRegion, map => map.MapFrom(s => s.ColRegion));
    }
}
