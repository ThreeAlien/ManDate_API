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
              List <GetReportInfo> respData = await _context.SysReport
                .Where(x => string.IsNullOrEmpty(request.ReportName) || x.ReportName.Contains(request.ReportName.Trim()))
                .Where(x => string.IsNullOrEmpty(request.ReportGoalAds) || x.ReportGoalAds == request.ReportGoalAds.Trim())
                .Where(x => string.IsNullOrEmpty(request.ReportMedia) || x.ReportMedia == request.ReportMedia.Trim())
                .Where(x => string.IsNullOrEmpty(request.StartDate) || x.CreateDate >= Convert.ToDateTime(request.StartDate))
                .Where(x => string.IsNullOrEmpty(request.EndDate) || x.CreateDate < Convert.ToDateTime(request.EndDate).AddDays(1))
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
                })
                .OrderByDescending(x => x.EditDate)
                .ToListAsync();

            GetReportResponse response = new()
            {
                Data = _mapper.Map<List<GetReportInfo>>(respData)
            };

            return response;
        }
    }
}