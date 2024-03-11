using AutoMapper;
using mandate.Domain.Models.ReportExport;
using mandate.Domain.Po;
using mandate.Domain.Vo;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace mandate.Application.ReportExport;

/// <summary>
/// 報表匯出 - 性別 CommandHandler
/// </summary>
public class ReportExportGenderCommandHandler : IRequestHandler<ReportExportGenderRequest, ReportExportGenderResponse>
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
    public ReportExportGenderCommandHandler(IMapper mapper, ManDateDBContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ReportExportGenderResponse> Handle(ReportExportGenderRequest request, CancellationToken cancellationToken)
    {
        ReportExportGenderResponse response = new();
        try
        {
            List<SysAdsDataGenderViewPo> respData = await _context.SysAdsDataGenderView.ToListAsync();

            if (!String.IsNullOrEmpty(request.CampaignID)) respData = respData.Where(x => x.CampaignID == request.CampaignID).ToList();
            if (request.StartDate != null) respData = respData.Where(x => Convert.ToDateTime(x.ColDate) >= request.StartDate).ToList();
            if (request.EndDate != null) respData = respData.Where(x => Convert.ToDateTime(x.ColDate) <= request.EndDate).ToList();

            List<ReportExportGenderVo> genderResponse = respData
            .GroupBy(g => g.ColGender)
            .Select(group =>
            {
                string gender = group.Key;
                int impressions = group.Sum(x => int.Parse(x.ColImpressions));
                int clicks = group.Sum(x => int.Parse(x.ColClicks));
                double ctr = group.Sum(x => double.Parse(x.ColCTR));
                double cpc = group.Sum(x => double.Parse(x.ColCPC));
                double cost = group.Sum(x => double.Parse(x.ColCost));

                return new ReportExportGenderVo()
                {
                    Gender = gender,
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
                Data = _mapper.Map<List<ReportExportGenderVo>>(genderResponse)
            };
        }
        catch (Exception ex)
        {
            throw ex;
        }


        return response;
    }
}
