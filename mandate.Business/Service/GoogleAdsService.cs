using Google.Ads.GoogleAds;
using Google.Ads.GoogleAds.Config;
using Google.Ads.GoogleAds.Lib;
using Google.Ads.GoogleAds.V15.Errors;
using Google.Ads.GoogleAds.V15.Services;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Microsoft.Extensions.Configuration;
using Google.Ads.GoogleAds.V15.Resources;
using Google.Api.Gax;

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
    /// 取得Ads報表 Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public void FetchAdsReportApi(string refreshToken)
    {
        GoogleAdsOption option = _configuration.GetSection(GoogleAdsOption.SectionName).Get<GoogleAdsOption>();
        GoogleAdsConfig config = new GoogleAdsConfig()
        {
            DeveloperToken = option.DeveloperToken,
            OAuth2Mode = Google.Ads.Gax.Config.OAuth2Flow.APPLICATION,
            OAuth2ClientId = option.ClientId,
            OAuth2ClientSecret = option.ClientSecret,
            OAuth2RefreshToken = refreshToken,
            LoginCustomerId = option.LoginCustomerId,
        };
        GoogleAdsClient client = new GoogleAdsClient(config);

        GoogleAdsServiceClient googleAdsService = client.GetService(
        Services.V15.GoogleAdsService);

        string query = @"SELECT 
  campaign.name, 
  metrics.clicks, 
  metrics.ctr, 
  metrics.average_cpc, 
  metrics.cost_micros, 
  segments.date, 
  segments.week, 
  ad_group.name 
FROM ad_group_ad 
WHERE 
  segments.date BETWEEN '2000-01-01' AND '2023-12-31'";

        try
        {
            string custId = "5133521829";
            // Issue a search request.
            googleAdsService.SearchStream(custId, query,
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

    /// <summary>
    /// 取得Ads帳戶(權限管理用) Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public void FetchAdsAccountApi(string refreshToken)
    {
        GoogleAdsOption option = _configuration.GetSection(GoogleAdsOption.SectionName).Get<GoogleAdsOption>();
        GoogleAdsConfig config = new GoogleAdsConfig()
        {
            DeveloperToken = option.DeveloperToken,
            OAuth2Mode = Google.Ads.Gax.Config.OAuth2Flow.APPLICATION,
            OAuth2ClientId = option.ClientId,
            OAuth2ClientSecret = option.ClientSecret,
            OAuth2RefreshToken = refreshToken,
            LoginCustomerId = option.LoginCustomerId,
        };
        GoogleAdsClient client = new GoogleAdsClient(config);

        // Get the CustomerService.
        CustomerServiceClient customerService = client.GetService(Services.V15.CustomerService);

        try
        {
            // Retrieve the list of customer resources.
            string[] customerResourceNames = customerService.ListAccessibleCustomers();

            // Display the result.
            foreach (string customerResourceName in customerResourceNames)
            {
                Console.WriteLine(
                    $"Found customer with resource name = '{customerResourceName}'.");
            }
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

    /// <summary>
    /// 取得子帳號
    /// </summary>
    /// <param name="refreshToken"></param>
    public void FetchAdsSubAccountApi(string? refreshToken)
    {
        GoogleAdsOption option = _configuration.GetSection(GoogleAdsOption.SectionName).Get<GoogleAdsOption>();
        GoogleAdsConfig config = new GoogleAdsConfig()
        {
            DeveloperToken = option.DeveloperToken,
            OAuth2Mode = Google.Ads.Gax.Config.OAuth2Flow.APPLICATION,
            OAuth2ClientId = option.ClientId,
            OAuth2ClientSecret = option.ClientSecret,
            OAuth2RefreshToken = refreshToken,
            LoginCustomerId = option.LoginCustomerId,
        };
        GoogleAdsClient client = new GoogleAdsClient(config);
        client.Config.LoginCustomerId = option.LoginCustomerId;

        GoogleAdsServiceClient googleAdsServiceClient =
                client.GetService(Services.V15.GoogleAdsService);

        CustomerServiceClient customerServiceClient =
                client.GetService(Services.V15.CustomerService);

        // List of Customer IDs to handle.
        List<long> seedCustomerIds = new List<long>();

        string[] customerResourceNames = customerServiceClient.ListAccessibleCustomers();

        foreach (string customerResourceName in customerResourceNames)
        {
            CustomerName customerName = CustomerName.Parse(customerResourceName);
            seedCustomerIds.Add(long.Parse(customerName.CustomerId));
        }

        string query = @"SELECT
                                    customer_client.client_customer,
                                    customer_client.level,
                                    customer_client.manager,
                                    customer_client.descriptive_name,
                                    customer_client.currency_code,
                                    customer_client.time_zone,
                                    customer_client.id
                                FROM customer_client
                                WHERE
                                    customer_client.level <= 1 AND customer_client.manager = FALSE";

        Dictionary<long, List<CustomerClient>> customerIdsToChildAccounts =
                new Dictionary<long, List<CustomerClient>>();

        long? managerCustomerId = 0;
        foreach (long seedCustomerId in seedCustomerIds)
        {
            Queue<long> unprocessedCustomerIds = new Queue<long>();
            unprocessedCustomerIds.Enqueue(seedCustomerId);
            CustomerClient rootCustomerClient = null;

            while (unprocessedCustomerIds.Count > 0)
            {
                managerCustomerId = unprocessedCustomerIds.Dequeue();
                PagedEnumerable<SearchGoogleAdsResponse, GoogleAdsRow> response =
                    googleAdsServiceClient.Search(
                        managerCustomerId.ToString(),
                        query,
                        pageSize: 40
                    );
                foreach (GoogleAdsRow googleAdsRow in response)
                {
                    CustomerClient customerClient = googleAdsRow.CustomerClient;

                    if (customerClient.Level == 0)
                    {
                        if (rootCustomerClient == null)
                        {
                            rootCustomerClient = customerClient;
                        }

                        continue;
                    }
                    if (!customerIdsToChildAccounts.ContainsKey(managerCustomerId.Value))
                        customerIdsToChildAccounts.Add(managerCustomerId.Value,
                            new List<CustomerClient>());

                    customerIdsToChildAccounts[managerCustomerId.Value].Add(customerClient);

                    if (customerClient.Manager)
                        if (!customerIdsToChildAccounts.ContainsKey(customerClient.Id) &&
                            customerClient.Level == 1)
                            unprocessedCustomerIds.Enqueue(customerClient.Id);
                }
            }
            var a = rootCustomerClient;
            var b = customerIdsToChildAccounts;
            var c = 0;
        }
    }
}
