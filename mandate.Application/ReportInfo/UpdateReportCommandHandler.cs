using AutoMapper;
using mandate.Domain.Models;
using mandate.Domain.Po;
using mandate.Domain.Vo;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

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
                    _context.SaveChanges();

                    if (request.ColumnData.Count() > 0)
                    {
                        foreach (ReportColumnDataVo item in request.ColumnData)
                        {
                            // 若該資料的isDelete是true，就刪除
                            if (item.IsDelete)
                            {
                                SysReportColumnPo? DelSysReportColumnData = _context.SysReportColumn.Where(s => s.ReportNo == item.ReportNo).FirstOrDefault();
                                _context.Remove(DelSysReportColumnData);
                                _context.SaveChanges();
                            }
                            // 若該資料的ReportNo不為null，就更新
                            else if (item.ReportNo != null)
                            {
                                SysReportColumnPo? SysReportColumnData = _context.SysReportColumn.Where(s => s.ReportNo == item.ReportNo).FirstOrDefault();
                                SysReportColumnData.IsColAccount = item.ColAccount;
                                SysReportColumnData.IsColCutomerID = item.ColCutomerID;
                                SysReportColumnData.IsColCampaignName = item.ColCampaignName;
                                SysReportColumnData.IsColAdGroupName = item.ColAdGroupName;
                                SysReportColumnData.IsColAdFinalURL = item.ColAdFinalURL;
                                SysReportColumnData.IsColHeadline = item.ColHeadline;
                                SysReportColumnData.IsColHeadLine_1 = item.ColHeadLine_1;
                                SysReportColumnData.IsColHeadLine_2 = item.ColHeadLine_2;
                                SysReportColumnData.IsColDirections = item.ColDirections;
                                SysReportColumnData.IsColDirections_1 = item.ColDirections_1;
                                SysReportColumnData.IsColDirections_2 = item.ColDirections_2;
                                SysReportColumnData.IsColAdName = item.ColAdName;
                                SysReportColumnData.IsColSrchKeyWord = item.ColSrchKeyWord;
                                SysReportColumnData.IsColConGoal = item.ColConGoal;
                                SysReportColumnData.IsColConValue = item.ColConValue;
                                SysReportColumnData.IsColConByDate = item.ColConByDate;
                                SysReportColumnData.IsColConPerCost = item.ColConPerCost;
                                SysReportColumnData.IsColCon = item.ColCon;
                                SysReportColumnData.IsColConRate = item.ColConRate;
                                SysReportColumnData.IsColClicks = item.ColClicks;
                                SysReportColumnData.IsColImpressions = item.ColImpressions;
                                SysReportColumnData.IsColCTR = item.ColCTR;
                                SysReportColumnData.IsColCPC = item.ColCPC;
                                SysReportColumnData.IsColCost = item.ColCost;
                                SysReportColumnData.ContentId = item.ContentId;
                                SysReportColumnData.IsColAge = item.ColAge;
                                SysReportColumnData.IsColGender = item.ColGender;
                                SysReportColumnData.IsColConstant = item.ColConstant;
                                SysReportColumnData.IsColConAction = item.ColConAction;
                                SysReportColumnData.IsColCPA = item.ColCPA;
                                SysReportColumnData.IsColStartDate = item.ColStartDate;
                                SysReportColumnData.IsColEndDate = item.ColEndDate;

                                _context.Update(SysReportColumnData);
                                _context.SaveChanges();
                            }
                            // 若該資料的ReportNo為null，就新增
                            else
                            {
                                ReportColumnVo ReportColumn = _mapper.Map<ReportColumnVo>(item);
                                ReportColumn.ColumnId = objUpdateData.ColumnID;

                                SysReportColumnPo CreateReportColumn = _mapper.Map<SysReportColumnPo>(ReportColumn);

                                _context.Add(CreateReportColumn);
                                _context.SaveChanges();

                            }
                        }
                    }
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