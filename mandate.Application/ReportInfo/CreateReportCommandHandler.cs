using AutoMapper;
using mandate.Domain.Models;
using mandate.Domain.Po;
using mandate.Domain.Vo;
using mandate.Infrastructure;
using MediatR;

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
                    ReportID = request.ReportId,
                    ReportName = request.ReportName,
                    ReportGoalAds = request.ReportGoalAds,
                    ReportMedia = request.ReportMedia,
                    SubID = request.SubID,
                    Creater = request.Creater,
                    CreateDate = DateTime.Now,
                    ReportStatus = request.ReportStatus
                };
                // 先映射，並給一個uuid給ColumnId
                List<ReportColumnVo> ReportColumn = _mapper.Map<List<ReportColumnVo>>(request.ColumnData);
                ReportColumn.ForEach(x => x.ColumnId = DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                // 再映射給DB
                List<SysReportColumnPo> CreateReportColumn = _mapper.Map<List<SysReportColumnPo>>(ReportColumn);
                _context.Add(CreateReport);
                _context.AddRange(CreateReportColumn);
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