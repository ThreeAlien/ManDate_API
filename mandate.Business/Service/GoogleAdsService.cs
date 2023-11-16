using Google.Ads.GoogleAds;
using Google.Ads.GoogleAds.Config;
using Google.Ads.GoogleAds.Lib;
using Google.Ads.GoogleAds.V15.Errors;
using Google.Ads.GoogleAds.V15.Services;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Microsoft.Extensions.Configuration;

namespace mandate.Business.Service;

/// <summary>
/// Google ADS服務
/// </summary>
public class GoogleAdsService : IGoogleAdsService
{
    /// <summary>
    /// Config設定檔
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    /// 建構子
    /// </summary>
    /// <param name="configuration"></param>
    public GoogleAdsService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// 產生RefreshToken
    /// </summary>
    /// <returns></returns>
    public Task<string?> GenerateRefreshToken()
    {
        string? refreshToken = null;
        GoogleAdsOption option = _configuration.GetSection(GoogleAdsOption.SectionName).Get<GoogleAdsOption>();
        ClientSecrets secrets = new()
        {
            ClientId = option.ClientId,
            ClientSecret = option.ClientSecret
        };

        try
        {
            GoogleAuthorizationCodeFlow.Initializer initializer = new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = secrets,
                Prompt = "consent",
            };

            Task<UserCredential> task = GoogleWebAuthorizationBroker.AuthorizeAsync(
                initializer,
                new string[] { option.Scope },
                string.Empty,
                CancellationToken.None,
                new NullDataStore()
            );
            UserCredential credential = task.Result;

            refreshToken = credential.Token.RefreshToken;
        }
        catch (AggregateException)
        {
            Console.WriteLine("An error occured while authorizing the user.");
        }

        return Task.FromResult(refreshToken);
    }

    /// <summary>
    /// 取得Ads Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public void FetchAdsApi(string refreshToken)
    {
        GoogleAdsOption option = _configuration.GetSection(GoogleAdsOption.SectionName).Get<GoogleAdsOption>();
        GoogleAdsConfig config = new GoogleAdsConfig()
        {
            DeveloperToken = option.DeveloperToken,
            OAuth2Mode = Google.Ads.Gax.Config.OAuth2Flow.APPLICATION,
            OAuth2ClientId = option.ClientId,
            OAuth2ClientSecret = option.ClientSecret,
            OAuth2RefreshToken = refreshToken,
            LoginCustomerId = option.LoginCustomerId
        };
        GoogleAdsClient client = new GoogleAdsClient(config);

        GoogleAdsServiceClient googleAdsService = client.GetService(
        Services.V15.GoogleAdsService);

        string query = @"SELECT
                    campaign.id,
                    campaign.name,
                    campaign.network_settings.target_content_network
                FROM campaign
                ORDER BY campaign.id";

        try
        {
            // Issue a search request.
            googleAdsService.SearchStream(option.LoginCustomerId, query,
                delegate (SearchGoogleAdsStreamResponse resp)
                {
                    var test = resp.Results;
                    foreach (GoogleAdsRow googleAdsRow in resp.Results)
                    {
                        Console.WriteLine("Campaign with ID {0} and name '{1}' was found.",
                            googleAdsRow.Campaign.Id, googleAdsRow.Campaign.Name);
                    }
                }
            );
        }
        catch (GoogleAdsException e)
        {
            Console.WriteLine("Failure:");
            Console.WriteLine($"Message: {e.Message}");
            Console.WriteLine($"Failure: {e.Failure}");
            Console.WriteLine($"Request ID: {e.RequestId}");
            throw;
        }
    }
}
