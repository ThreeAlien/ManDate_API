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
                        objUpdateColumnData.IsColAccount = request.ColumnData.ColAccount;
                        objUpdateColumnData.IsColCutomerID = request.ColumnData.ColCutomerID;
                        objUpdateColumnData.IsColCampaignID = request.ColumnData.ColCampaignID;
                        objUpdateColumnData.IsColAdGroupID = request.ColumnData.ColAdGroupID;
                        objUpdateColumnData.IsColAdFinalURL = request.ColumnData.ColAdFinalURL;
                        objUpdateColumnData.IsColHeadline = request.ColumnData.ColHeadline;
                        objUpdateColumnData.IsColShortHeadLine = request.ColumnData.ColShortHeadLine;
                        objUpdateColumnData.IsColLongHeadLine = request.ColumnData.ColLongHeadLine;
                        objUpdateColumnData.IsColHeadLine_1 = request.ColumnData.ColHeadLine_1;
                        objUpdateColumnData.IsColHeadLine_2 = request.ColumnData.ColHeadLine_2;
                        objUpdateColumnData.IsColDirections = request.ColumnData.ColDirections;
                        objUpdateColumnData.IsColDirections_1 = request.ColumnData.ColDirections_1;
                        objUpdateColumnData.IsColDirections_2 = request.ColumnData.ColDirections_2;
                        objUpdateColumnData.IsColAdName = request.ColumnData.ColAdName;
                        objUpdateColumnData.IsColAdPath_1 = request.ColumnData.ColAdPath_1;
                        objUpdateColumnData.IsColAdPath_2 = request.ColumnData.ColAdPath_2;
                        objUpdateColumnData.IsColSrchKeyWord = request.ColumnData.ColSrchKeyWord;
                        objUpdateColumnData.IsColSwitchTarget = request.ColumnData.ColSwitchTarget;
                        objUpdateColumnData.IsColDateTime = request.ColumnData.ColDateTime;
                        objUpdateColumnData.IsColWeek = request.ColumnData.ColWeek;
                        objUpdateColumnData.IsColSeason = request.ColumnData.ColSeason;
                        objUpdateColumnData.IsColMonth = request.ColumnData.ColMonth;
                        objUpdateColumnData.IsColIncome = request.ColumnData.ColIncome;
                        objUpdateColumnData.IsColTransTime = request.ColumnData.ColTransTime;
                        objUpdateColumnData.IsColTransCostOnce = request.ColumnData.ColTransCostOnce;
                        objUpdateColumnData.IsColTrans = request.ColumnData.ColTrans;
                        objUpdateColumnData.IsColTransRate = request.ColumnData.ColTransRate;
                        objUpdateColumnData.IsColClick = request.ColumnData.ColClick;
                        objUpdateColumnData.IsColImpression = request.ColumnData.ColImpression;
                        objUpdateColumnData.IsColCTR = request.ColumnData.ColCTR;
                        objUpdateColumnData.IsColCPC = request.ColumnData.ColCPC;
                        objUpdateColumnData.IsColCost = request.ColumnData.ColCost;
                        objUpdateColumnData.ContentId = request.ColumnData.ContentId;
                        objUpdateColumnData.ColumnId = request.ColumnData.ColumnId;
                        objUpdateColumnData.IsColAge = request.ColumnData.ColAge;
                        objUpdateColumnData.IsColSex = request.ColumnData.ColSex;
                        objUpdateColumnData.IsColRegion = request.ColumnData.ColRegion;

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