using AutoMapper;
using mandate.Domain.Models;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace mandate.Application.ReportInfo
{
    /// <summary>
    /// 取得報表內容資料
    /// </summary>
    public class CreateReportCommandHandler : IRequestHandler<CreateReportRequest, CreateReportResponse>
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
        public CreateReportCommandHandler(IMapper mapper, ManDateDBContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<CreateReportResponse> Handle(CreateReportRequest request, CancellationToken cancellationToken)
        {
            CreateReportResponse response = new();
            try
            {
                SysReportPo CreateReport = new()
                {
                    ReportID = request.ReportID,
                    ReportName = request.ReportName,
                    ReportGoalAds = request.ReportGoalAds,
                    ReportMedia = request.ReportMedia,
                    ContentID = request.ContentID,
                    SubID = request.SubID,
                    Editer = request.Editer,
                    EditDate = DateTime.Now,
                    Creater = request.Creater,
                    CreateDate = DateTime.Now,
                    ReportStatus = request.ReportStatus

                };

                SysReportColumnPo CreateReportColumn = new()
                {
                    ColAccount = request.ColumnData.ColAccount,
                    ColCutomerID = request.ColumnData.ColCutomerID,
                    ColCampaignID = request.ColumnData.ColCampaignID,
                    ColAdGroupID = request.ColumnData.ColAdGroupID,
                    ColAdFinalURL = request.ColumnData.ColAdFinalURL,
                    ColHeadline = request.ColumnData.ColHeadline,
                    ColShortHeadLine = request.ColumnData.ColShortHeadLine,
                    ColLongHeadLine = request.ColumnData.ColLongHeadLine,
                    ColHeadLine_1 = request.ColumnData.ColHeadLine_1,
                    ColHeadLine_2 = request.ColumnData.ColHeadLine_2,
                    ColDirections = request.ColumnData.ColDirections,
                    ColDirections_1 = request.ColumnData.ColDirections_1,
                    ColDirections_2 = request.ColumnData.ColDirections_2,
                    ColAdName = request.ColumnData.ColAdName,
                    ColAdPath_1 = request.ColumnData.ColAdPath_1,
                    ColAdPath_2 = request.ColumnData.ColAdPath_2,
                    ColSrchKeyWord = request.ColumnData.ColSrchKeyWord,
                    ColSwitchTarget = request.ColumnData.ColSwitchTarget,
                    ColDateTime = request.ColumnData.ColDateTime,
                    ColWeek = request.ColumnData.ColWeek,
                    ColSeason = request.ColumnData.ColSeason,
                    ColMonth = request.ColumnData.ColMonth,
                    ColIncome = request.ColumnData.ColIncome,
                    ColTransTime = request.ColumnData.ColTransTime,
                    ColTransCostOnce = request.ColumnData.ColTransCostOnce,
                    ColTrans = request.ColumnData.ColTrans,
                    ColTransRate = request.ColumnData.ColTransRate,
                    ColClick = request.ColumnData.ColClick,
                    ColImpression = request.ColumnData.ColImpression,
                    ColCTR = request.ColumnData.ColCTR,
                    ColCPC = request.ColumnData.ColCPC,
                    ColCost = request.ColumnData.ColCost,
                    ContentId = request.ColumnData.ContentId,
                    ColumnId = request.ColumnData.ColumnId,
                    ColAge = request.ColumnData.ColAge,
                    ColSex = request.ColumnData.ColSex,
                    ColRegion = request.ColumnData.ColRegion
                };
                _context.Add(CreateReport);
                _context.Add(CreateReportColumn);
                await _context.SaveChangesAsync();

                 response = new()
                {
                    Code = "200",
                    Data = null,
                    Msg = "Success"
                };
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Code = "404",
                    Data = null,
                    Msg = ex.ToString()
                 };
            }


            return response;
        }
    }
}