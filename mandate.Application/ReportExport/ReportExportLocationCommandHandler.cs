using AutoMapper;
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
/// 報表匯出 - 地點 CommandHandler
/// </summary>
public class ReportExportLocationCommandHandler : IRequestHandler<ReportExportLocationRequest, ReportExportLocationResponse>
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
    public ReportExportLocationCommandHandler(IMapper mapper, ManDateDBContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ReportExportLocationResponse> Handle(ReportExportLocationRequest request, CancellationToken cancellationToken)
    {
        ReportExportLocationResponse response = new();
        try
        {
            List<SysAdsDataLocationViewPo> respData = await _context.SysAdsDataLocationView.ToListAsync();

            if (!String.IsNullOrEmpty(request.CampaignID)) respData = respData.Where(x => x.CampaignID == request.CampaignID).ToList();
            if (!String.IsNullOrEmpty(request.StartDate)) respData = respData.Where(x => Convert.ToDateTime(x.ColDate) >= Convert.ToDateTime(request.StartDate)).ToList();
            if (!String.IsNullOrEmpty(request.EndDate)) respData = respData.Where(x => Convert.ToDateTime(x.ColDate) <= Convert.ToDateTime(request.EndDate)).ToList();

            List<ReportExportLocationVo> locationResponse = respData
            .GroupBy(g => g.ColConstant)
            .Select(group =>
            {
                string location = group.Key;
                int impressions = group.Sum(x => int.Parse(x.ColImpressions));
                int clicks = group.Sum(x => int.Parse(x.ColClicks));
                double ctr = group.Sum(x => double.Parse(x.ColCTR));
                double cpc = group.Sum(x => double.Parse(x.ColCPC));
                double cost = group.Sum(x => double.Parse(x.ColCost));

                return new ReportExportLocationVo()
                {
                    Location = location,
                    Impressions = impressions,
                    Click = clicks,
                    CTR = ctr.ToString("P", CultureInfo.InvariantCulture),
                    CPC = cpc,
                    Cost = cost
                };
            })
            .ToList();

            response = new()
            {
                Data = _mapper.Map<List<ReportExportLocationVo>>(locationResponse)
            };
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return response;
    }
}