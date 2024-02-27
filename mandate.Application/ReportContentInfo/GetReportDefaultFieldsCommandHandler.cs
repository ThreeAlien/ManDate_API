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
            List<ReportDefaultFields> result = _context.SysReportColumn
                                                .Join(_context.SysReportContent, column => column.ContentId, content => content.ContentID, (column, content) => new { column, content.ContentName }).Select(x => new ReportDefaultFields
                                                {
                                                    ContentId = x.column.ContentId,
                                                    ContentName = x.ContentName,
                                                    IsColAccount = x.column.IsColAccount,
                                                    IsColAdGroupName = x.column.IsColAdGroupName,
                                                    IsColCampaignName = x.column.IsColCampaignName,
                                                    //IsColLongHeadLine = x.column.IsColLongHeadLine,
                                                    IsColCutomerID = x.column.IsColCutomerID,
                                                    IsColAdFinalURL = x.column.IsColAdFinalURL,
                                                    IsColHeadline = x.column.IsColHeadline,
                                                    //IsColShortHeadLine = x.column.IsColHeadline,
                                                    IsColHeadLine_1 = x.column.IsColHeadLine_1,
                                                    IsColHeadLine_2 = x.column.IsColHeadLine_2,
                                                    IsColDirections = x.column.IsColDirections,
                                                    IsColDirections_1 = x.column.IsColDirections_1,
                                                    IsColDirections_2 = x.column.IsColDirections_2,
                                                    IsColAdName = x.column.IsColAdName,
                                                    //IsColAdPath_1 = x.column.IsColAdPath_1,
                                                    //IsColAdPath_2 = x.column.IsColAdPath_2,
                                                    IsColSrchKeyWord = x.column.IsColSrchKeyWord,
                                                    IsColConGoal = x.column.IsColConGoal,
                                                    //IsColDateTime = x.column.IsColDateTime,
                                                    //IsColWeek = x.column.IsColWeek,
                                                    //IsColSeason = x.column.IsColSeason,
                                                    //IsColMonth = x.column.IsColMonth,
                                                    IsColConValue = x.column.IsColConValue,
                                                    IsColConByDate = x.column.IsColConByDate,
                                                    IsColConPerCost = x.column.IsColConPerCost,
                                                    IsColCon = x.column.IsColCon,
                                                    IsColConRate = x.column.IsColConRate,
                                                    IsColClicks = x.column.IsColClicks,
                                                    IsColImpressions = x.column.IsColImpressions,
                                                    IsColCTR = x.column.IsColCTR,
                                                    IsColCPC = x.column.IsColCPC,
                                                    IsColCost = x.column.IsColCost,
                                                    IsColAge = x.column.IsColAge,
                                                    IsColGender = x.column.IsColGender,
                                                    IsColConstant = x.column.IsColConstant,
                                                    IsColStartDate = x.column.IsColStartDate,
                                                    IsColEndDate = x.column.IsColEndDate,
                                                }).ToList();



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
