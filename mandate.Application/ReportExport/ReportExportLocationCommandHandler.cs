using AutoMapper;
using mandate.Domain.Models.ReportExport;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

            response = new()
            {
                Data = _mapper.Map<List<SysAdsDataLocationViewPo>>(respData)
            };
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return response;
    }
}