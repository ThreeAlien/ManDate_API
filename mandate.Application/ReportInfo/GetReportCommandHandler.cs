using AutoMapper;
using mandate.Domain.Models;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;

namespace mandate.Application.ReportInfo
{
    /// <summary>
    /// 取得報表內容資料
    /// </summary>
    public class GetReportCommandHandler : IRequestHandler<GetReportRequest, GetReportResponse>
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
        public GetReportCommandHandler(IMapper mapper, ManDateDBContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetReportResponse> Handle(GetReportRequest request, CancellationToken cancellationToken)
        {
            List<SysReportPo> respData = await _context.SysReport.ToListAsync();

            List<GetReportInfo> result = _context.SysReport
                                        .Join(_context.SysSubClient, report => report.SubID, subClient => subClient.SubId, (report, subClient) => new { report, subClient.SubName, subClient.ClientId }).Select(x => new GetReportInfo
                                        {
                                            ReportID = x.report.ReportID,
                                            ReportName = x.report.ReportName,
                                            ClienId = x.ClientId,
                                            SubClientName = x.SubName,
                                            ReportGoalAds = x.report.ReportGoalAds,
                                            ReportMedia = x.report.ReportMedia,
                                            ReportStatus = x.report.ReportStatus,
                                            ColumnID = x.report.ColumnID,
                                            SubID = x.report.SubID,
                                            EditDate = x.report.EditDate,
                                            Editer = x.report.Editer,
                                            Creater = x.report.Creater,
                                            CreateDate = x.report.CreateDate,
                                        }).ToList();

            if (!String.IsNullOrEmpty(request.ReportName)) result = result.Where(x => x.ReportName.Contains(request.ReportName)).ToList();
            if (!String.IsNullOrEmpty(request.ReportGoalAds)) result = result.Where(x => x.ReportGoalAds == request.ReportGoalAds).ToList();
            if (!String.IsNullOrEmpty(request.ReportMedia)) result = result.Where(x => x.ReportMedia == request.ReportMedia).ToList();
            if (!String.IsNullOrEmpty(request.StartDate)) result = result.Where(x => Convert.ToDateTime(request.StartDate) <= x.CreateDate).ToList();
            if (!String.IsNullOrEmpty(request.EndDate)) result = result.Where(x => Convert.ToDateTime(request.EndDate) >= x.CreateDate).ToList();

            GetReportResponse response = new()
            {
                Data = _mapper.Map<List<GetReportInfo>>(result)
            };

            return response;
        }
    }
}