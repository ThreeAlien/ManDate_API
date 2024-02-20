using mandate.Business.Service;
using mandate.Domain.Models.Sso;
using MediatR;

namespace mandate.Application.Sso;

public class SingleSignOnCommandHandler : IRequestHandler<SingleSignOnRequest, SingleSignOnResponse>
{
    /// <summary>
    /// Google Ads服務
    /// </summary>
    private readonly IGoogleAdsService _googleAdsService;

    /// <summary>
    /// 建構子
    /// </summary>
    public SingleSignOnCommandHandler(IGoogleAdsService googleAdsService)
    {
        _googleAdsService = googleAdsService;
    }

    public async Task<SingleSignOnResponse> Handle(SingleSignOnRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _googleAdsService.SingleSignOn();
        }
        catch (Exception ex)
        {
            return new SingleSignOnResponse()
            {
                Code = "400",
                Data = null,
                Msg = ex.Message.ToString()
            };
        }

        return new SingleSignOnResponse()
        {
            Code = "200",
            Data = null,
            Msg = "success"
        };
    }
}