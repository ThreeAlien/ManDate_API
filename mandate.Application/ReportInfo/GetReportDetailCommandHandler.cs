using AutoMapper;
using mandate.Domain.Models;
using mandate.Domain.Models.Report;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace mandate.Application.ReportInfo;

public class GetReportDetailCommandHandler : IRequestHandler<GetReportDetailRequest, GetReportDetailResponse>
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
    public GetReportDetailCommandHandler(IMapper mapper, ManDateDBContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<GetReportDetailResponse> Handle(GetReportDetailRequest request, CancellationToken cancellationToken)
    {
        List<SysReportColumnPo> respData = await _context.SysReportColumn.ToListAsync();

        if (!String.IsNullOrEmpty(request.ColumnID)) respData = respData.Where(x => x.ColumnId == request.ColumnID).ToList();

        GetReportDetailResponse response = new()
        {
            Data = _mapper.Map<List<SysReportColumnPo>>(respData)
        };

        return response;
    }
}
