using AutoMapper;
using mandate.Domain.Models;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Data.SqlTypes;

namespace mandate.Application.ReportInfo
{
    /// <summary>
    /// 取得報表內容資料
    /// </summary>
    public class UpdateReportCommandHandler : IRequestHandler<UpdateReportRequest, UpdateReportResponse>
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
        public UpdateReportCommandHandler(IMapper mapper, ManDateDBContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UpdateReportResponse> Handle(UpdateReportRequest request, CancellationToken cancellationToken)
        {
            UpdateReportResponse response = new();
            try
            {
                SysReportPo? objUpdateData = await _context.SysReport.Where(s => s.ReportID == request.ReportID).FirstOrDefaultAsync();
                SysReportColumnPo? objUpdateColumnData = await _context.SysReportColumn.Where(s => s.ColumnId == request.ColumnData.ColumnId).FirstOrDefaultAsync();

                if (objUpdateData != null)
                {
                    objUpdateData.ReportName = request.ReportName;
                    objUpdateData.ReportGoalAds = request.ReportGoalAds;
                    objUpdateData.ReportMedia = request.ReportMedia;
                    objUpdateData.SubID = request.SubID;
                    objUpdateData.Editer = request.Editer;
                    objUpdateData.EditDate = DateTime.Now;
                    objUpdateData.Creater = request.Creater;
                    objUpdateData.CreateDate = DateTime.Now;
                    objUpdateData.ReportStatus = request.ReportStatus;

                    _context.Update(objUpdateData);

                    if (objUpdateColumnData != null)
                    {
                        objUpdateColumnData.ColAccount = request.ColumnData.ColAccount;
                        objUpdateColumnData.ColCutomerID = request.ColumnData.ColCutomerID;
                        objUpdateColumnData.ColCampaignID = request.ColumnData.ColCampaignID;
                        objUpdateColumnData.ColAdGroupID = request.ColumnData.ColAdGroupID;
                        objUpdateColumnData.ColAdFinalURL = request.ColumnData.ColAdFinalURL;
                        objUpdateColumnData.ColHeadline = request.ColumnData.ColHeadline;
                        objUpdateColumnData.ColShortHeadLine = request.ColumnData.ColShortHeadLine;
                        objUpdateColumnData.ColLongHeadLine = request.ColumnData.ColLongHeadLine;
                        objUpdateColumnData.ColHeadLine_1 = request.ColumnData.ColHeadLine_1;
                        objUpdateColumnData.ColHeadLine_2 = request.ColumnData.ColHeadLine_2;
                        objUpdateColumnData.ColDirections = request.ColumnData.ColDirections;
                        objUpdateColumnData.ColDirections_1 = request.ColumnData.ColDirections_1;
                        objUpdateColumnData.ColDirections_2 = request.ColumnData.ColDirections_2;
                        objUpdateColumnData.ColAdName = request.ColumnData.ColAdName;
                        objUpdateColumnData.ColAdPath_1 = request.ColumnData.ColAdPath_1;
                        objUpdateColumnData.ColAdPath_2 = request.ColumnData.ColAdPath_2;
                        objUpdateColumnData.ColSrchKeyWord = request.ColumnData.ColSrchKeyWord;
                        objUpdateColumnData.ColSwitchTarget = request.ColumnData.ColSwitchTarget;
                        objUpdateColumnData.ColDateTime = request.ColumnData.ColDateTime;
                        objUpdateColumnData.ColWeek = request.ColumnData.ColWeek;
                        objUpdateColumnData.ColSeason = request.ColumnData.ColSeason;
                        objUpdateColumnData.ColMonth = request.ColumnData.ColMonth;
                        objUpdateColumnData.ColIncome = request.ColumnData.ColIncome;
                        objUpdateColumnData.ColTransTime = request.ColumnData.ColTransTime;
                        objUpdateColumnData.ColTransCostOnce = request.ColumnData.ColTransCostOnce;
                        objUpdateColumnData.ColTrans = request.ColumnData.ColTrans;
                        objUpdateColumnData.ColTransRate = request.ColumnData.ColTransRate;
                        objUpdateColumnData.ColClick = request.ColumnData.ColClick;
                        objUpdateColumnData.ColImpression = request.ColumnData.ColImpression;
                        objUpdateColumnData.ColCTR = request.ColumnData.ColCTR;
                        objUpdateColumnData.ColCPC = request.ColumnData.ColCPC;
                        objUpdateColumnData.ColCost = request.ColumnData.ColCost;
                        objUpdateColumnData.ContentId = request.ColumnData.ContentId;
                        objUpdateColumnData.ColumnId = request.ColumnData.ColumnId;
                        objUpdateColumnData.ColAge = request.ColumnData.ColAge;
                        objUpdateColumnData.ColSex = request.ColumnData.ColSex;
                        objUpdateColumnData.ColRegion = request.ColumnData.ColRegion;

                        _context.Update(objUpdateColumnData);
                    }

                    _context.SaveChanges();
                }

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