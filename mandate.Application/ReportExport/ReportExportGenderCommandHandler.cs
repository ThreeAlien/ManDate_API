using AutoMapper;
using mandate.Domain.Models.ReportExport;
using mandate.Domain.Po;
using mandate.Domain.Vo;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace mandate.Application.ReportExport;

/// <summary>
/// 報表匯出 - 性別 CommandHandler
/// </summary>
public class ReportExportGenderCommandHandler : IRequestHandler<ReportExportGenderRequest, ReportExportGenderResponse>
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
    public ReportExportGenderCommandHandler(IMapper mapper, ManDateDBContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ReportExportGenderResponse> Handle(ReportExportGenderRequest request, CancellationToken cancellationToken)
    {
        ReportExportGenderResponse response = new();
        try
        {
            List<SysAdsDataGenderViewPo> respData = await _context.SysAdsDataGenderView.ToListAsync();

            if (!String.IsNullOrEmpty(request.CampaignID)) respData = respData.Where(x => x.CampaignID == request.CampaignID).ToList();
            if (request.StartDate != null) respData = respData.Where(x => Convert.ToDateTime(x.ColDate) >= request.StartDate).ToList();
            if (request.EndDate != null) respData = respData.Where(x => Convert.ToDateTime(x.ColDate) <= request.EndDate).ToList();

            IEnumerable<SysAdsDataGenderViewPo> MaleRspData = respData.Where(s => s.ColGender == "Male");
            IEnumerable<SysAdsDataGenderViewPo> FemaleRspData = respData.Where(s => s.ColGender == "Female");
            IEnumerable<SysAdsDataGenderViewPo> UndeterminedRspData = respData.Where(s => s.ColGender == "Undetermined");

            List<ReportExportGenderVo> genderResponse = new()
        {
            new ReportExportGenderVo()
            {
                Gender = "Male",
                Impressions = MaleRspData.Sum(item => Int32.Parse(item.ColImpressions)),
                Click = MaleRspData.Sum(item => Int32.Parse(item.ColClicks)),
                CTR = MaleRspData.Sum(item => double.Parse(item.ColCTR)).ToString("P", CultureInfo.InvariantCulture),
                CPC = MaleRspData.Sum(item => double.Parse(item.ColCPC)),
                Cost = MaleRspData.Sum(item => double.Parse(item.ColCost)),
            },
            new ReportExportGenderVo()
            {
                Gender = "Female",
                Impressions = FemaleRspData.Sum(item => Int32.Parse(item.ColImpressions)),
                Click = FemaleRspData.Sum(item => Int32.Parse(item.ColClicks)),
                CTR = FemaleRspData.Sum(item => double.Parse(item.ColCTR)).ToString("P", CultureInfo.InvariantCulture),
                CPC = FemaleRspData.Sum(item => double.Parse(item.ColCPC)),
                Cost = FemaleRspData.Sum(item => double.Parse(item.ColCost)),
            },
            new ReportExportGenderVo()
            {
                Gender = "Undetermined",
                Impressions = UndeterminedRspData.Sum(item => Int32.Parse(item.ColImpressions)),
                Click = UndeterminedRspData.Sum(item => Int32.Parse(item.ColClicks)),
                CTR = UndeterminedRspData.Sum(item => double.Parse(item.ColCTR)).ToString("P", CultureInfo.InvariantCulture),
                CPC = UndeterminedRspData.Sum(item => double.Parse(item.ColCPC)),
                Cost = UndeterminedRspData.Sum(item => double.Parse(item.ColCost)),
            }
        };

            response = new()
            {
                Data = _mapper.Map<List<ReportExportGenderVo>>(genderResponse)
            };
        }
        catch (Exception ex)
        {
            throw ex;
        }


        return response;
    }
}
