using AutoMapper;
using mandate.Business.Service;
using mandate.Domain.Models.ReportContent;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace mandate.Application.ReportContentInfo;

/// <summary>
/// 取得報表預設欄位
/// </summary>
public class GetReportDefaultFieldsCommandHandler : IRequestHandler<GetReportDefaultFieldsRequest, GetReportDefaultFieldsResponse>
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
    public GetReportDefaultFieldsCommandHandler(IMapper mapper, ManDateDBContext context, IGoogleAdsService googleAdsService)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<GetReportDefaultFieldsResponse> Handle(GetReportDefaultFieldsRequest request, CancellationToken cancellationToken)
    {
        GetReportDefaultFieldsResponse response = new();
        try
        {
            List<SysReportColumnPo> sysReportColumnData = await _context.SysReportColumn.ToListAsync();
            List<SysReportContentPo> sysReportContentData = await _context.SysReportContent.ToListAsync();
            // Join Table
            List<SysReportColumnPo> result = sysReportColumnData
            .Join(sysReportContentData, column => column.ContentId, content => content.ContentID, (content, column) => content)
            .ToList();

            response = new()
            {
                Data = _mapper.Map<List<ReportDefaultFields>>(result)
            };
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return response;
    }
}
