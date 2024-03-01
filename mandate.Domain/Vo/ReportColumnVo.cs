using AutoMapper;
using mandate.Domain.Po;
using mandate.Helper.Mapper;

namespace mandate.Domain.Vo;

/// <summary>
/// 報表欄位 Vo
/// </summary>
public class ReportColumnVo : IMapTo<SysReportColumnPo>
{
    public int? ReportNo { get; set; }
    public bool? ColAccount { get; set; }
    public bool? ColCutomerID { get; set; }
    public bool? ColCampaignName { get; set; }
    public bool? ColAdGroupName { get; set; }
    public bool? ColAdFinalURL { get; set; }
    public bool? ColHeadline { get; set; }
    public bool? ColHeadLine_1 { get; set; }
    public bool? ColHeadLine_2 { get; set; }
    public bool? ColDirections { get; set; }
    public bool? ColDirections_1 { get; set; }
    public bool? ColDirections_2 { get; set; }
    public bool? ColAdName { get; set; }
    public bool? ColSrchKeyWord { get; set; }
    public bool? ColConGoal { get; set; }
    public bool? ColConValue { get; set; }
    public bool? ColConByDate { get; set; }
    public bool? ColConPerCost { get; set; }
    public bool? ColCon { get; set; }
    public bool? ColConRate { get; set; }
    public bool? ColClicks { get; set; }
    public bool? ColImpressions { get; set; }
    public bool? ColCTR { get; set; }
    public bool? ColCPC { get; set; }
    public bool? ColCost { get; set; }
    public string ContentId { get; set; } = null!;
    public string ColumnId { get; set; } = null!;
    public bool? ColAge { get; set; }
    public bool? ColGender { get; set; }
    public bool? ColConstant { get; set; }

    public bool? ColConAction { get; set; }

    public bool? ColCPA { get; set; }

    public bool? ColStartDate { get; set; }

    public bool? ColEndDate { get; set; }

    /// <summary>
    /// 此資料是否刪除
    /// </summary>
    public bool IsDelete { get; set; }

    void IMapTo<SysReportColumnPo>.Mapping(Profile profile)
    {
        profile.CreateMap<ReportColumnVo, SysReportColumnPo>()
            .ForMember(d => d.IsColAccount, map => map.MapFrom(s => s.ColAccount))
            .ForMember(d => d.IsColCutomerID, map => map.MapFrom(s => s.ColCutomerID))
            .ForMember(d => d.IsColAdGroupName, map => map.MapFrom(s => s.ColAdGroupName))
            .ForMember(d => d.IsColCampaignName, map => map.MapFrom(s => s.ColCampaignName))
            .ForMember(d => d.IsColAdFinalURL, map => map.MapFrom(s => s.ColAdFinalURL))
            .ForMember(d => d.IsColHeadline, map => map.MapFrom(s => s.ColHeadline))
            .ForMember(d => d.IsColHeadLine_1, map => map.MapFrom(s => s.ColHeadLine_1))
            .ForMember(d => d.IsColHeadLine_2, map => map.MapFrom(s => s.ColHeadLine_2))
            .ForMember(d => d.IsColDirections, map => map.MapFrom(s => s.ColDirections))
            .ForMember(d => d.IsColDirections_1, map => map.MapFrom(s => s.ColDirections_1))
            .ForMember(d => d.IsColDirections_2, map => map.MapFrom(s => s.ColDirections_2))
            .ForMember(d => d.IsColAdName, map => map.MapFrom(s => s.ColAdName))
            .ForMember(d => d.IsColSrchKeyWord, map => map.MapFrom(s => s.ColSrchKeyWord))
            .ForMember(d => d.IsColConGoal, map => map.MapFrom(s => s.ColConGoal))
            .ForMember(d => d.IsColConValue, map => map.MapFrom(s => s.ColConValue))
            .ForMember(d => d.IsColConByDate, map => map.MapFrom(s => s.ColConByDate))
            .ForMember(d => d.IsColConPerCost, map => map.MapFrom(s => s.ColConPerCost))
            .ForMember(d => d.IsColCon, map => map.MapFrom(s => s.ColCon))
            .ForMember(d => d.IsColConRate, map => map.MapFrom(s => s.ColConRate))
            .ForMember(d => d.IsColClicks, map => map.MapFrom(s => s.ColClicks))
            .ForMember(d => d.IsColImpressions, map => map.MapFrom(s => s.ColImpressions))
            .ForMember(d => d.IsColCTR, map => map.MapFrom(s => s.ColCTR))
            .ForMember(d => d.IsColCPC, map => map.MapFrom(s => s.ColCPC))
            .ForMember(d => d.IsColCost, map => map.MapFrom(s => s.ColCost))
            .ForMember(d => d.ContentId, map => map.MapFrom(s => s.ContentId))
            .ForMember(d => d.ColumnId, map => map.MapFrom(s => s.ColumnId))
            .ForMember(d => d.IsColAge, map => map.MapFrom(s => s.ColAge))
            .ForMember(d => d.IsColGender, map => map.MapFrom(s => s.ColGender))
            .ForMember(d => d.IsColConstant, map => map.MapFrom(s => s.ColConstant))
            .ForMember(d => d.IsColConAction, map => map.MapFrom(s => s.ColConAction))
            .ForMember(d => d.IsColCPA, map => map.MapFrom(s => s.ColCPA))
            .ForMember(d => d.IsColStartDate, map => map.MapFrom(s => s.ColStartDate))
            .ForMember(d => d.IsColEndDate, map => map.MapFrom(s => s.ColEndDate));
    }
}
