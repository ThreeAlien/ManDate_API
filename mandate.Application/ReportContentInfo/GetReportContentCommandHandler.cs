using AutoMapper;
using mandate.Domain.Models.ReportContent;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace mandate.Application.ReportContentInfo
{
    /// <summary>
    /// 取得報表內容資料
    /// </summary>
    public class GetReportContentCommandHandler : IRequestHandler<GetReportContentRequest, GetReportContentResponse>
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
        public GetReportContentCommandHandler(IMapper mapper, ManDateDBContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetReportContentResponse> Handle(GetReportContentRequest request, CancellationToken cancellationToken)
        {
            GetReportContentResponse response = new();
            try
            {
                List<SysReportContentPo> respData = await _context.SysReportContent.ToListAsync();

                response = new()
                {
                    Data = _mapper.Map<List<GetReportContentInfo>>(respData)
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

    }
}