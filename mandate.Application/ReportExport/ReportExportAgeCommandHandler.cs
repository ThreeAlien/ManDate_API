using AutoMapper;
using mandate.Domain.Models.ReportExport;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

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


            response = new()
            {
                Data = _mapper.Map<List<SysAdsDataAgeViewPo>>(respData)
            };
        }
        catch (Exception ex)
        {
            throw ex;
        }


        return response;
    }
}