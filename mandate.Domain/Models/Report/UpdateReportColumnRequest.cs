using MediatR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Models;

/// <summary>
/// 取得報表資料 Request
/// </summary>
public class UpdateReportColumnRequest : IRequest<UpdateReportResponse>
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

}