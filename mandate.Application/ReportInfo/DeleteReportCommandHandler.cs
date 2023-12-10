using AutoMapper;
using mandate.Domain.Models;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace mandate.Application.ReportInfo
{
    /// <summary>
    /// 取得報表內容資料
    /// </summary>
    public class DeleteReportCommandHandler : IRequestHandler<DeleteReportRequest, DeleteReportResponse>
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
        public DeleteReportCommandHandler(IMapper mapper, ManDateDBContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<DeleteReportResponse> Handle(DeleteReportRequest request, CancellationToken cancellationToken)
        {
            DeleteReportResponse response = new();
            try
            {
                SysReportPo? objUpdateData = await _context.SysReport.Where(s => s.ReportID == request.ReportID).FirstOrDefaultAsync();

                if (objUpdateData != null)
                {
                    objUpdateData.ReportStatus = request.ReportStatus; // 這行要幹嘛?
                    _context.Remove(objUpdateData);
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