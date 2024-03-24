using AutoMapper;
using mandate.Business.Constants;
using mandate.Domain.Models.ReportExport;
using mandate.Domain.Po;
using mandate.Domain.Vo;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;

namespace mandate.Application.ReportExport;

/// <summary>
/// 報表匯出 - 每周或每日 CommandHandler
/// </summary>
public class ReportExportWithWeekOrDayCommandHandler : IRequestHandler<ReportExportWithWeekOrDayRequest, ReportExportWithWeekOrDayResponse>
{
    /// <summary>
    /// Db Context
    /// </summary>
    private readonly ManDateDBContext _context;

    /// <summary>
    /// mapper
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// 建構子
    /// </summary>
    public ReportExportWithWeekOrDayCommandHandler(IMapper mapper, ManDateDBContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ReportExportWithWeekOrDayResponse> Handle(ReportExportWithWeekOrDayRequest request, CancellationToken cancellationToken)
    {
        ReportExportWithWeekOrDayResponse response = new();
        try
        {
            List<SysAdsDataCampaignPo> respData = await _context.SysAdsDataCampaign.ToListAsync();

            #region request檢核
            if (request.Status.Length == 0 || string.IsNullOrEmpty(request.SubId))
            {
                return response = new()
                {
                    Code = "404",
                    Data = null,
                    Msg = "Status(Week Or Day)、CampaignID為必填"
                };
            }
            #endregion

            #region Data Filter
            if (!String.IsNullOrEmpty(request.SubId)) respData = respData.Where(x => x.CustomerID == request.SubId).ToList();
            if (!String.IsNullOrEmpty(request.StartDate)) respData = respData.Where(x => Convert.ToDateTime(x.ColDate) >= Convert.ToDateTime(request.StartDate)).ToList();
            if (!String.IsNullOrEmpty(request.EndDate)) respData = respData.Where(x => Convert.ToDateTime(x.ColDate) < Convert.ToDateTime(request.EndDate).AddDays(1)).ToList();
            #endregion

            List<ReportExportWithWeekOrDayVo> reportResponse = new();
            if (request.Status.Contains(ReportExportStatus.Day))
            {
                List<ReportExportWithWeekOrDayVo> respDayData = respData
                .GroupBy(g => g.ColDate)
                .Select(group =>
                {
                    string date = group.Key;
                    int impressions = group.Sum(x => int.Parse(x.ColImpressions));
                    int clicks = group.Sum(x => int.Parse(x.ColClicks));                    
                    double cpc = group.Sum(x => double.Parse(x.ColCPC));                   
                    double ctr = (double)clicks / impressions;
                    double cost = clicks > 0 ? cpc * clicks : 0;

                    return new ReportExportWithWeekOrDayVo()
                    {
                        Date = date,
                        Impressions = impressions,
                        Click = clicks,
                        CTR = ctr.ToString("P", CultureInfo.InvariantCulture),
                        CPC = cpc,
                        Cost = cost,
                        DataType = "Day"
                    };
                })
                .ToList();


                reportResponse.AddRange(respDayData);
            }

            if (request.Status.Contains(ReportExportStatus.Week))
            {
                List<ReportExportWithWeekOrDayVo> respWeekData = respData
                .GroupBy(g => GetWeekStartDate(g.ColDate))
                .Select(group =>
                {
                    DateTime endDate = GetWeekEndDate((DateTime)group.Key);
                    string location = group.Key.Value.ToString("yyyy/MM/dd") + "~" + endDate.ToString("yyyy/MM/dd");
                    int impressions = group.Sum(x => int.Parse(x.ColImpressions));
                    int clicks = group.Sum(x => int.Parse(x.ColClicks));
                    double ctr = group.Sum(x => double.Parse(x.ColCTR));
                    double cpc = group.Sum(x => double.Parse(x.ColCPC));
                    double cost = group.Sum(x => double.Parse(x.ColCost));

                    return new ReportExportWithWeekOrDayVo()
                    {
                        Date = location,
                        Impressions = impressions,
                        Click = clicks,
                        CTR = ctr.ToString("P", CultureInfo.InvariantCulture),
                        CPC = cpc,
                        Cost = cost,
                        DataType = "Week"
                    };
                })
                .ToList();

                reportResponse.AddRange(respWeekData);
            }


            response = new()
            {
                Data = _mapper.Map<List<ReportExportWithWeekOrDayVo>>(reportResponse)
            };
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return response;
    }

    // 取得給定日期所在週的開始日期
    private static DateTime? GetWeekStartDate(string? date)
    {
        if (string.IsNullOrEmpty(date)) return null;
        DateTime dateTime = Convert.ToDateTime(date);
        int diff = (7 + (dateTime.DayOfWeek - DayOfWeek.Monday)) % 7;
        return dateTime.AddDays(-1 * diff).Date;
    }

    // 取得給定日期所在週的結束日期
    private static DateTime GetWeekEndDate(DateTime date)
    {
        int diff = ((int)DayOfWeek.Saturday - (int)date.DayOfWeek + 7) % 7;
        return date.AddDays(diff + 1).Date;
    }
}
