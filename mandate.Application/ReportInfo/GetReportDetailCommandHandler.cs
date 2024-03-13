using AutoMapper;
using mandate.Domain.Models.Report;
using mandate.Infrastructure;
using MediatR;

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
        GetReportDetailResponse response = new();
        try
        {
            List<ReportDetailFields> result = _context.SysReportColumn
                                                .Join(_context.SysReportContent, column => column.ContentId, content => content.ContentID, (column, content) => new { column, content.ContentName }).Select(x => new ReportDetailFields
                                                {
                                                    ContentName = x.ContentName,
                                                    IsColAccount = x.column.IsColAccount,
                                                    IsColCutomerID = x.column.IsColCutomerID,
                                                    IsColCampaignName = x.column.IsColCampaignName,
                                                    IsColAdGroupName = x.column.IsColAdGroupName,
                                                    IsColAdFinalURL = x.column.IsColAdFinalURL,
                                                    IsColHeadline = x.column.IsColHeadline,
                                                    IsColHeadLine_1 = x.column.IsColHeadLine_1,
                                                    IsColHeadLine_2 = x.column.IsColHeadLine_2,
                                                    IsColDirections = x.column.IsColDirections,
                                                    IsColDirections_1 = x.column.IsColDirections_1,
                                                    IsColDirections_2 = x.column.IsColDirections_2,
                                                    IsColAdName = x.column.IsColAdName,
                                                    IsColSrchKeyWord = x.column.IsColSrchKeyWord,
                                                    IsColConGoal = x.column.IsColConGoal,
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
                                                    ContentId = x.column.ContentId,
                                                    ColumnId = x.column.ColumnId,
                                                    IsColAge = x.column.IsColAge,
                                                    IsColGender = x.column.IsColGender,
                                                    IsColConstant = x.column.IsColConstant,
                                                    IsColConAction = x.column.IsColConAction,
                                                    IsColCPA = x.column.IsColCPA,
                                                    IsColStartDate = x.column.IsColStartDate,
                                                    IsColEndDate = x.column.IsColEndDate,
                                                    ContentSort = x.column.ContentSort,
                                                    IsDefault = x.column.IsDefault,
                                                }).ToList();

            if (!String.IsNullOrEmpty(request.ColumnID)) result = result.Where(x => x.ColumnId == request.ColumnID).ToList();

            response = new()
            {
                Data = _mapper.Map<List<ReportDetailFields>>(result)
            };
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return response;
    }
}
