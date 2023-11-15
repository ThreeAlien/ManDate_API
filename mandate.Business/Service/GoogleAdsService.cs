using Google.Ads.GoogleAds;
using Google.Ads.GoogleAds.Config;
using Google.Ads.GoogleAds.Lib;
using Google.Ads.GoogleAds.V15.Errors;
using Google.Ads.GoogleAds.V15.Services;

namespace mandate.Business.Service;

public class GoogleAdsService
{
    public static void FetchAdsApi(string refreshToken)
    {
        long customerId = 6749631325;
        GoogleAdsConfig config = new GoogleAdsConfig()
        {
            DeveloperToken = "Gfds_Yqxe_aj9bTuNa2wIQ",
            OAuth2Mode = Google.Ads.Gax.Config.OAuth2Flow.APPLICATION,
            OAuth2ClientId = "732004983478-a26k8c3a5piuedeekitriknhcihirvtg.apps.googleusercontent.com",
            OAuth2ClientSecret = "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",
            OAuth2RefreshToken = refreshToken,
            LoginCustomerId = "6749631325"
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
            googleAdsService.SearchStream(customerId.ToString(), query,
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
