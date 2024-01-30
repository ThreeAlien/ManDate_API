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
            IQueryable<SysReportColumnPo> qry = _context.SysReportColumn
                                                .Join(_context.SysReportContent, column => column.ContentId, content => content.ContentID, (column, content) => column)
                                                .AsQueryable();
            List<SysReportColumnPo> result = await qry
                                            .Select(x => new SysReportColumnPo
                                            {
                                                ContentId = x.ContentId,
                                                IsColAccount = x.IsColAccount,
                                                IsColCutomerID = x.IsColCutomerID,
                                                IsColAdFinalURL = x.IsColAdFinalURL,
                                                IsColHeadline = x.IsColHeadline,
                                                IsColShortHeadLine = x.IsColHeadline,
                                                IsColHeadLine_1 = x.IsColHeadLine_1,
                                                IsColHeadLine_2 = x.IsColHeadLine_2,
                                                IsColDirections = x.IsColDirections,
                                                IsColDirections_1 = x.IsColDirections_1,
                                                IsColDirections_2 = x.IsColDirections_2,
                                                IsColAdName = x.IsColAdName,
                                                IsColAdPath_1 = x.IsColAdPath_1,
                                                IsColAdPath_2 = x.IsColAdPath_2,
                                                IsColSrchKeyWord = x.IsColSrchKeyWord,
                                                IsColSwitchTarget = x.IsColSwitchTarget,
                                                IsColDateTime = x.IsColDateTime,
                                                IsColWeek = x.IsColWeek,
                                                IsColSeason = x.IsColSeason,
                                                IsColMonth = x.IsColMonth,
                                                IsColIncome = x.IsColIncome,
                                                IsColTransTime = x.IsColTransTime,
                                                IsColTransCostOnce = x.IsColTransCostOnce,
                                                IsColTrans = x.IsColTrans,
                                                IsColTransRate = x.IsColTransRate,
                                                IsColClick = x.IsColClick,
                                                IsColImpression = x.IsColImpression,
                                                IsColCTR = x.IsColCTR,
                                                IsColCPC = x.IsColCPC,
                                                IsColCost = x.IsColCost,
                                                IsColAge = x.IsColAge,
                                                IsColSex = x.IsColSex,
                                                IsColRegion = x.IsColRegion,
                                            }).ToListAsync();           
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
