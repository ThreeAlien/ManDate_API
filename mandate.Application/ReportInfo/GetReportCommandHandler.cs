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

            if (!String.IsNullOrEmpty(request.ReportName)) respData = respData.Where(x => x.ReportName == request.ReportName).ToList();
            if (!String.IsNullOrEmpty(request.ReportGoalAds)) respData = respData.Where(x => x.ReportGoalAds == request.ReportGoalAds).ToList();
            if (!String.IsNullOrEmpty(request.ReportMedia)) respData = respData.Where(x => x.ReportMedia == request.ReportMedia).ToList();
            if (!String.IsNullOrEmpty(request.ReportID)) respData = respData.Where(x => x.ReportID == request.ReportID).ToList();
            if (!String.IsNullOrEmpty(request.StartDate)) respData = respData.Where(x => Convert.ToDateTime(request.StartDate) < x.CreateDate).ToList();
            if (!String.IsNullOrEmpty(request.EndDate)) respData = respData.Where(x => Convert.ToDateTime(request.EndDate) > x.CreateDate).ToList();

            GetReportResponse response = new()
            {
                Data = _mapper.Map<List<GetReportInfo>>(respData)
            };

            return response;
        }
    }
}