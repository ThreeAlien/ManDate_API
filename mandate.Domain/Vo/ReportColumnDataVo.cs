using AutoMapper;
using mandate.Helper.Mapper;

namespace mandate.Domain.Vo;

public class ReportColumnDataVo : IMapTo<ReportColumnVo>
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

    void IMapTo<ReportColumnVo>.Mapping(Profile profile)
    {
        profile.CreateMap<ReportColumnDataVo, ReportColumnVo>()
            .ForMember(d => d.ColAccount, map => map.MapFrom(s => s.ColAccount))
            .ForMember(d => d.ColCutomerID, map => map.MapFrom(s => s.ColCutomerID))
            .ForMember(d => d.ColAdGroupName, map => map.MapFrom(s => s.ColAdGroupName))
            .ForMember(d => d.ColCampaignName, map => map.MapFrom(s => s.ColCampaignName))
            .ForMember(d => d.ColAdFinalURL, map => map.MapFrom(s => s.ColAdFinalURL))
            .ForMember(d => d.ColHeadline, map => map.MapFrom(s => s.ColHeadline))
            .ForMember(d => d.ColHeadLine_1, map => map.MapFrom(s => s.ColHeadLine_1))
            .ForMember(d => d.ColHeadLine_2, map => map.MapFrom(s => s.ColHeadLine_2))
            .ForMember(d => d.ColDirections, map => map.MapFrom(s => s.ColDirections))
            .ForMember(d => d.ColDirections_1, map => map.MapFrom(s => s.ColDirections_1))
            .ForMember(d => d.ColDirections_2, map => map.MapFrom(s => s.ColDirections_2))
            .ForMember(d => d.ColAdName, map => map.MapFrom(s => s.ColAdName))
            .ForMember(d => d.ColSrchKeyWord, map => map.MapFrom(s => s.ColSrchKeyWord))
            .ForMember(d => d.ColConGoal, map => map.MapFrom(s => s.ColConGoal))
            .ForMember(d => d.ColConValue, map => map.MapFrom(s => s.ColConValue))
            .ForMember(d => d.ColConByDate, map => map.MapFrom(s => s.ColConByDate))
            .ForMember(d => d.ColConPerCost, map => map.MapFrom(s => s.ColConPerCost))
            .ForMember(d => d.ColCon, map => map.MapFrom(s => s.ColCon))
            .ForMember(d => d.ColConRate, map => map.MapFrom(s => s.ColConRate))
            .ForMember(d => d.ColClicks, map => map.MapFrom(s => s.ColClicks))
            .ForMember(d => d.ColImpressions, map => map.MapFrom(s => s.ColImpressions))
            .ForMember(d => d.ColCTR, map => map.MapFrom(s => s.ColCTR))
            .ForMember(d => d.ColCPC, map => map.MapFrom(s => s.ColCPC))
            .ForMember(d => d.ColCost, map => map.MapFrom(s => s.ColCost))
            .ForMember(d => d.ContentId, map => map.MapFrom(s => s.ContentId))
            .ForMember(d => d.ColumnId, map => map.Ignore())
            .ForMember(d => d.ColAge, map => map.MapFrom(s => s.ColAge))
            .ForMember(d => d.ColGender, map => map.MapFrom(s => s.ColGender))
            .ForMember(d => d.ColConstant, map => map.MapFrom(s => s.ColConstant))
            .ForMember(d => d.ColConAction, map => map.MapFrom(s => s.ColConAction))
            .ForMember(d => d.ColCPA, map => map.MapFrom(s => s.ColCPA))
            .ForMember(d => d.ColStartDate, map => map.MapFrom(s => s.ColStartDate))
            .ForMember(d => d.ColEndDate, map => map.MapFrom(s => s.ColEndDate));
    }
}
