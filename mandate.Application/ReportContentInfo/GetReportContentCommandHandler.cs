using AutoMapper;
using mandate.Business.Constants;
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
                List<SysReportContentPo> respData = await _context.SysReportContent.Where(content => content.ContentID == request.ContentID).ToListAsync();

                response = new()
                {
                    Code = ResponseCode.Success,
                    Data = _mapper.Map<List<GetReportContentInfo>>(respData),
                    Msg = ResponseMsg.Success
                };
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Code = ResponseCode.Error,
                    Data = null,
                    Msg = ex.ToString()
                };
            }

            return response;
        }

    }
}