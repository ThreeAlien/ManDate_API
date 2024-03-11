using AutoMapper;
using mandate.Domain.Models.ReportExport;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace mandate.Application.ReportExport;

/// <summary>
/// 報表匯出 - 關鍵字 CommandHandler
/// </summary>
public class ReportExportKeyWordCommandHandler : IRequestHandler<ReportExportKeyWordRequest, ReportExportKeyWordResponse>
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
    public ReportExportKeyWordCommandHandler(IMapper mapper, ManDateDBContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ReportExportKeyWordResponse> Handle(ReportExportKeyWordRequest request, CancellationToken cancellationToken)
    {
        ReportExportKeyWordResponse response = new();
        try
        {
            List<SysAdsDataKeywordViewPo> respData = await _context.SysAdsDataKeywordView.ToListAsync();

            if (!String.IsNullOrEmpty(request.KeyWord)) respData = respData.Where(x => x.ColSrchKeyWord == request.KeyWord).ToList();

            response = new()
            {
                Data = _mapper.Map<List<SysAdsDataKeywordViewPo>>(respData)
            };
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return response;
    }
}