﻿using AutoMapper;
using mandate.Business.Constants;
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
            List<SysReportPo> respData = new();
            GetReportResponse response = new();
            try
            {
                respData = request.ReportID != string.Empty ? await _context.SysReport.Where(x => x.ReportID == request.ReportID).ToListAsync() : await _context.SysReport.ToListAsync();

                response = new()
                {
                    Code = ResponseCode.Success,
                    Data = _mapper.Map<List<GetReportInfo>>(respData),
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