﻿using AutoMapper;
using mandate.Domain.Models.ReportExport;
using mandate.Domain.Po;
using mandate.Domain.Vo;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace mandate.Application.ReportExport;

/// <summary>
/// 報表匯出 - 年齡 CommandHandler
/// </summary>
public class ReportExportAgeCommandHandler : IRequestHandler<ReportExportAgeRequest, ReportExportAgeResponse>
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
    public ReportExportAgeCommandHandler(IMapper mapper, ManDateDBContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ReportExportAgeResponse> Handle(ReportExportAgeRequest request, CancellationToken cancellationToken)
    {
        ReportExportAgeResponse response = new();
        try
        {
            List<SysAdsDataAgeViewPo> respData = await _context.SysAdsDataAgeView.ToListAsync();

            if (!String.IsNullOrEmpty(request.CampaignID)) respData = respData.Where(x => x.CampaignID == request.CampaignID).ToList();
            if (request.StartDate != null) respData = respData.Where(x => x.ColDate >= request.StartDate).ToList();
            if (request.EndDate != null) respData = respData.Where(x => x.ColDate <= request.EndDate).ToList();

            List<ReportExportAgeVo> ageResponse = respData
            .GroupBy(g => g.ColAge)
            .Select(group =>
            {
                string age = group.Key;
                int impressions = group.Sum(x => int.Parse(x.ColImpressions));
                int clicks = group.Sum(x => int.Parse(x.ColClicks));
                double ctr = group.Sum(x => double.Parse(x.ColCTR));
                double cpc = group.Sum(x => double.Parse(x.ColCPC));
                double cost = group.Sum(x => double.Parse(x.ColCost));

                return new ReportExportAgeVo()
                {
                    Age = age,
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
                Data = _mapper.Map<List<ReportExportAgeVo>>(ageResponse)
            };
        }
        catch (Exception ex)
        {
            throw ex;
        }


        return response;
    }
}