using AutoMapper;
using mandate.Business.Models;
using mandate.Domain.Po;
using mandate.Helper.Mapper;

namespace mandate.Domain.Models.Report;

/// <summary>
/// 取得報表詳細資訊 Response
/// </summary>
public class GetReportDetailResponse : BaseResponse<List<ReportDetailFields>>
{
}

/// <summary>
/// 報表詳細欄位
/// </summary>
public class ReportDetailFields : IMapFrom<SysReportColumnPo>
{
    public int? ReportNo { get; set; }

    public string ContentName { get; set; } = null!;

    public bool? IsColAccount { get; set; }

    public bool? IsColCutomerID { get; set; }

    public bool? IsColCampaignName { get; set; }

    public bool? IsColAdGroupName { get; set; }

    public bool? IsColAdFinalURL { get; set; }

    public bool? IsColHeadline { get; set; }

    public bool? IsColHeadLine_1 { get; set; }

    public bool? IsColHeadLine_2 { get; set; }

    public bool? IsColDirections { get; set; }

    public bool? IsColDirections_1 { get; set; }

    public bool? IsColDirections_2 { get; set; }

    public bool? IsColAdName { get; set; }


    public bool? IsColSrchKeyWord { get; set; }

    public bool? IsColConGoal { get; set; }

    public bool? IsColConValue { get; set; }

    public bool? IsColConByDate { get; set; }

    public bool? IsColConPerCost { get; set; }

    public bool? IsColCon { get; set; }

    public bool? IsColConRate { get; set; }

    public bool? IsColClicks { get; set; }

    public bool? IsColImpressions { get; set; }

    public bool? IsColCTR { get; set; }

    public bool? IsColCPC { get; set; }

    public bool? IsColCost { get; set; }

    public string ContentId { get; set; } = null!;

    public string ColumnId { get; set; } = null!;

    public bool? IsColAge { get; set; }

    public bool? IsColGender { get; set; }

    public bool? IsColConstant { get; set; }

    public bool? IsColConAction { get; set; }

    public bool? IsColCPA { get; set; }

    public bool? IsColStartDate { get; set; }

    public bool? IsColEndDate { get; set; }

    public string? ContentSort { get; set; } = null!;

    /// <summary>
    /// 是否為預設欄位
    /// </summary>
    public bool? IsDefault { get; set; }

    void IMapFrom<SysReportColumnPo>.Mapping(Profile profile)
    {
        profile.CreateMap<SysReportColumnPo, ReportDetailFields>()
            .ForMember(d => d.ContentName, map => map.Ignore())
            .ForMember(d => d.IsColAccount, map => map.MapFrom(s => s.IsColAccount))
            .ForMember(d => d.IsColCutomerID, map => map.MapFrom(s => s.IsColCutomerID))
            .ForMember(d => d.IsColCampaignName, map => map.MapFrom(s => s.IsColCampaignName))
            .ForMember(d => d.IsColAdGroupName, map => map.MapFrom(s => s.IsColAdGroupName))
            .ForMember(d => d.IsColAdFinalURL, map => map.MapFrom(s => s.IsColAdFinalURL))
            .ForMember(d => d.IsColHeadline, map => map.MapFrom(s => s.IsColHeadline))
            .ForMember(d => d.IsColHeadLine_1, map => map.MapFrom(s => s.IsColHeadLine_1))
            .ForMember(d => d.IsColHeadLine_2, map => map.MapFrom(s => s.IsColHeadLine_2))
            .ForMember(d => d.IsColDirections, map => map.MapFrom(s => s.IsColDirections))
            .ForMember(d => d.IsColDirections_1, map => map.MapFrom(s => s.IsColDirections_1))
            .ForMember(d => d.IsColDirections_2, map => map.MapFrom(s => s.IsColDirections_2))
            .ForMember(d => d.IsColAdName, map => map.MapFrom(s => s.IsColAdName))
            .ForMember(d => d.IsColSrchKeyWord, map => map.MapFrom(s => s.IsColSrchKeyWord))
            .ForMember(d => d.IsColConGoal, map => map.MapFrom(s => s.IsColConGoal))
            .ForMember(d => d.IsColConValue, map => map.MapFrom(s => s.IsColConValue))
            .ForMember(d => d.IsColConByDate, map => map.MapFrom(s => s.IsColConByDate))
            .ForMember(d => d.IsColConPerCost, map => map.MapFrom(s => s.IsColConPerCost))
            .ForMember(d => d.IsColCon, map => map.MapFrom(s => s.IsColCon))
            .ForMember(d => d.IsColConRate, map => map.MapFrom(s => s.IsColConRate))
            .ForMember(d => d.IsColClicks, map => map.MapFrom(s => s.IsColClicks))
            .ForMember(d => d.IsColImpressions, map => map.MapFrom(s => s.IsColImpressions))
            .ForMember(d => d.IsColCTR, map => map.MapFrom(s => s.IsColCTR))
            .ForMember(d => d.IsColCPC, map => map.MapFrom(s => s.IsColCPC))
            .ForMember(d => d.IsColCost, map => map.MapFrom(s => s.IsColCost))
            .ForMember(d => d.ContentId, map => map.MapFrom(s => s.ContentId))
            .ForMember(d => d.ColumnId, map => map.MapFrom(s => s.ColumnId))
            .ForMember(d => d.IsColAge, map => map.MapFrom(s => s.IsColAge))
            .ForMember(d => d.IsColGender, map => map.MapFrom(s => s.IsColGender))
            .ForMember(d => d.IsColConstant, map => map.MapFrom(s => s.IsColConstant))
            .ForMember(d => d.IsColConAction, map => map.MapFrom(s => s.IsColConAction))
            .ForMember(d => d.IsColCPA, map => map.MapFrom(s => s.IsColCPA))
            .ForMember(d => d.IsColStartDate, map => map.MapFrom(s => s.IsColStartDate))
            .ForMember(d => d.IsColEndDate, map => map.MapFrom(s => s.IsColEndDate))
            .ForMember(d => d.ContentSort, map => map.MapFrom(s => s.ContentSort))
            .ForMember(d => d.IsDefault, map => map.MapFrom(s => s.IsDefault));
    }
}