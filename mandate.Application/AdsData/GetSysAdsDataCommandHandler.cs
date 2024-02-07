using mandate.Domain.Models.AdsData;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;
using System.Linq.Dynamic.Core;

namespace mandate.Application.AdsData;

public class GetSysAdsDataCommandHandler : IRequestHandler<GetSysAdsDataRequest, GetSysAdsDataResponse>
{
    /// <summary>
    /// Db Context
    /// </summary>
    private readonly ManDateDBContext _context;

    /// <summary>
    /// 建構子
    /// </summary>
    public GetSysAdsDataCommandHandler(ManDateDBContext context)
    {
        _context = context;
    }

    public async Task<GetSysAdsDataResponse> Handle(GetSysAdsDataRequest request, CancellationToken cancellationToken)
    {

        GetSysAdsDataResponse response = new();

        try
        {
            // 輸入檢核
            if (request.SelectFields == null)
            {
                return response = new()
                {
                    Code = "404",
                    Data = null,
                    Msg = "選擇查詢的欄位不可為null"
                };
            }

            IQueryable<SysAdsDataPo> queryData = _context.SysAdsData.AsQueryable();
            // 建立選擇字串
            string selectString = string.Join(",", request.SelectFields.Select(col => col));
            // 執行動態查詢
            List<SysAdsDataPo> respData = queryData.Where(x => x.SubClientNo == request.SubClientNo).Select<SysAdsDataPo>($"new({selectString})").ToList();
            // 將結果轉換成SysAdsDataPo並將null值設為"none"
            respData.ForEach(x =>
            {
                typeof(SysAdsDataPo).GetProperties().Where(prop => prop.GetValue(x) == null)
                .ToList()
                .ForEach(prop => prop.SetValue(x, "none"));
            });

            response = new()
            {
                Code = "200",
                Data = respData,
                Msg = null
            };
        }
        catch (Exception ex)
        {
            response.Msg = ex.Message;
        }

        return response;
    }
}