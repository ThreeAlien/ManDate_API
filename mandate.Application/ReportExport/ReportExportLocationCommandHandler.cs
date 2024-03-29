﻿using AutoMapper;
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

            if (!String.IsNullOrEmpty(request.SubId)) respData = respData.Where(x => x.CustomerID == request.SubId).ToList();
            if (!String.IsNullOrEmpty(request.StartDate)) respData = respData.Where(x => Convert.ToDateTime(x.ColDate) >= Convert.ToDateTime(request.StartDate)).ToList();
            if (!String.IsNullOrEmpty(request.EndDate)) respData = respData.Where(x => Convert.ToDateTime(x.ColDate) < Convert.ToDateTime(request.EndDate).AddDays(1)).ToList();

            List<ReportExportLocationVo> locationResponse = respData
            .GroupBy(g => g.ColConstant)
            .Select(group =>
            {
                string location = group.Key;
                int impressions = group.Sum(x => int.Parse(x.ColImpressions));
                int clicks = group.Sum(x => int.Parse(x.ColClicks));
                double cost = group.Sum(x => double.Parse(x.ColCost));
                double ctr = (double)clicks / impressions;
                double cpc = clicks > 0 ? cost / clicks : 0;

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