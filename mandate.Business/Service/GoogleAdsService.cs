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
    /// 取得AdsDataCampaign報表 Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public Task<Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>> FetchAdsDataCampaign(string refreshToken, string custId)
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

        string query = @"SELECT campaign.id, campaign.name, metrics.conversions, metrics.conversions_from_interactions_rate, metrics.cost_per_conversion, metrics.conversions_by_conversion_date, metrics.clicks, metrics.impressions, metrics.ctr, metrics.average_cpc, metrics.cost_micros, metrics.average_target_cpa_micros, metrics.conversions_value, metrics.all_conversions_value, customer.id, customer.resource_name, customer.status FROM campaign
WHERE customer.status = 'ENABLED'";

        Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> results = new Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>();
        try
        {
            // Issue a search request.
            googleAdsService.SearchStream(custId, query,
                delegate (SearchGoogleAdsStreamResponse resp)
                {
                    results = resp.Results;
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

        return Task.FromResult(results);
    }

    /// <summary>
    /// 取得AdsDataAdGroupAd報表 Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public Task<Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>> FetchAdsDataAdGroupAd(string refreshToken, string custId)
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

        string query = @"SELECT campaign.id
                            , ad_group_ad.ad.final_urls
                            , ad_group.name
                            , ad_group_ad.ad.expanded_text_ad.headline_part1
                            , ad_group_ad.ad.expanded_text_ad.headline_part2
                            , ad_group_ad.ad.expanded_text_ad.headline_part3
                            , ad_group_ad.ad.expanded_text_ad.description
                            , ad_group_ad.ad.expanded_text_ad.description2
                            , customer.id
                            , customer.resource_name
                             FROM ad_group_ad";

        Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> results = new Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>();
        try
        {
            // Issue a search request.
            googleAdsService.SearchStream(custId, query,
                delegate (SearchGoogleAdsStreamResponse resp)
                {
                        results = resp.Results;                 
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

        return Task.FromResult(results);
    }

    /// <summary>
    /// 取得CampaignAction報表 Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public Task<Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>> FetchAdsCampaignAction(string refreshToken, string custId)
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

        string query = @"SELECT customer.id, conversion_action.name, customer.resource_name, conversion_action.id FROM conversion_action";

        Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> results = new Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>();
        try
        {
            // Issue a search request.
            googleAdsService.SearchStream(custId, query,
                delegate (SearchGoogleAdsStreamResponse resp)
                {
                    if (resp.Results != null && resp.Results.Count > 0)
                    {
                        results = resp.Results;
                    }
                    //results = resp.Results;
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

        return Task.FromResult(results);
    }

    /// <summary>
    /// 取得AdGroupCriterion報表 Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public Task<Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>> FetchAdsAdGroupCriterion(string refreshToken, string custId)
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

        string query = @"SELECT campaign.id
                                    ,customer.id
                                    ,customer.resource_name
                                    ,ad_group_criterion.keyword.text
                                    ,ad_group_criterion.age_range.type
                                    ,ad_group_criterion.gender.type
                                     FROM ad_group_criterion
                                     WHERE customer.status = 'ENABLED'";

        Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> results = new Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>();
        try
        {
            // Issue a search request.
            googleAdsService.SearchStream(custId, query,
                delegate (SearchGoogleAdsStreamResponse resp)
                {
                    results = resp.Results;
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

        return Task.FromResult(results);
    }

    /// <summary>
    /// 取得AdsDataCampaignCon報表 Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public Task<Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>> FetchAdsDataCampaignCon(string refreshToken, string custId)
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

        string query = @"SELECT campaign.id
                                        , campaign_conversion_goal.resource_name
                                        , customer.id
                                        , customer.resource_name FROM campaign_conversion_goal";

        Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> results = new Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>();
        try
        {
            // Issue a search request.
            googleAdsService.SearchStream(custId, query,
                delegate (SearchGoogleAdsStreamResponse resp)
                {
                    results = resp.Results;
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

        return Task.FromResult(results);
    }

    /// <summary>
    /// 取得AdsDataCampaignCon報表 Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public Task<Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>> FetchAdsDataCampaignLocation(string refreshToken, string custId)
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

        string query = @"SELECT campaign_criterion.location.geo_target_constant
                                , campaign.name,campaign.id
                                , customer.id 
                        FROM location_view ";

        Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> results = new Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>();
        try
        {
            // Issue a search request.
            googleAdsService.SearchStream(custId, query,
                delegate (SearchGoogleAdsStreamResponse resp)
                {
                    var test = resp.Results;
                    foreach (GoogleAdsRow googleAdsRow in resp.Results)
                    {
                        var properties = googleAdsRow.GetType().GetProperties();
                        foreach (var property in properties)
                        {
                            var value = property.GetValue(googleAdsRow);
                            Console.WriteLine("{0}: {1}",
                                property.Name, value != null ? value.ToString() : "null");
                        }
                        Console.WriteLine("-----------------------------------------------------");
                    }

                    results = resp.Results;
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

        return Task.FromResult(results);
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
    /// 取得廣告帳戶
    /// </summary>
    /// <param name="refreshToken"></param>
    public List<SysClientPo> FetchAdsAdvertiseAccount(string? refreshToken)
    {
        var result = new List<SysClientPo>();
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
                            customer_client.level <= 2
                        AND customer.status = 'ENABLED'
                        AND customer_client.status = 'ENABLED'";

        Dictionary<long, List<CustomerClient>> customerIdsToChildAccounts =
                new Dictionary<long, List<CustomerClient>>();

        long? managerCustomerId = 0;
        int index = 0;
        //這個Gmail帳號底下有幾個帳戶(權限控管可以用)
        foreach (long seedCustomerId in seedCustomerIds)
        {
            index++;
            Queue<long> unprocessedCustomerIds = new Queue<long>();
            unprocessedCustomerIds.Enqueue(seedCustomerId);
            CustomerClient rootCustomerClient = null;
            //這隻帳號底下有幾個MCC(就是汎古客戶名稱)
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
                        customerIdsToChildAccounts.Add(managerCustomerId.Value, new List<CustomerClient>());

                    if (managerCustomerId.Value == 3255036910 && !customerClient.Manager)
                    {
                        if (customerClient.Level == 2)
                        {
                            string temp = customerClient.ResourceName;
                            temp = temp.Split('/')[3];
                            result.Add(new SysClientPo
                            {
                                ClientId = temp,
                                ClientNo = customerClient.Id,
                                ClientName = customerClient.DescriptiveName
                            });
                        }

                    }
                    customerIdsToChildAccounts[managerCustomerId.Value].Add(customerClient);

                    if (customerClient.Manager)
                        if (!customerIdsToChildAccounts.ContainsKey(customerClient.Id) &&
                            customerClient.Level == 1)
                            unprocessedCustomerIds.Enqueue(customerClient.Id);
                }
            }
            var a = rootCustomerClient;

            var b = customerIdsToChildAccounts;
            var c = unprocessedCustomerIds;
        }
        return result;
    }

    /// <summary>
    /// 取得子帳號
    /// </summary>
    /// <param name="refreshToken"></param>
    public List<SysClientPo> FetchAdsSubAccountApi(string? refreshToken)
    {
        var result = new List<SysClientPo>();
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
                                    customer_client.level <= 1 and customer_client.manager = true";

        Dictionary<long, List<CustomerClient>> customerIdsToChildAccounts =
                new Dictionary<long, List<CustomerClient>>();

        long? managerCustomerId = 0;
        int index = 0;
        //這個Gmail帳號底下有幾個帳戶(權限控管可以用)
        foreach (long seedCustomerId in seedCustomerIds)
        {
            index++;
            Queue<long> unprocessedCustomerIds = new Queue<long>();
            unprocessedCustomerIds.Enqueue(seedCustomerId);
            CustomerClient rootCustomerClient = null;
            //這隻帳號底下有幾個MCC(就是汎古客戶名稱)
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
                        customerIdsToChildAccounts.Add(managerCustomerId.Value, new List<CustomerClient>());
                    if (managerCustomerId.Value == 3255036910)
                    {
                        string temp = customerClient.ResourceName;
                        temp = temp.Split('/')[3];
                        result.Add(new SysClientPo
                        {
                            ClientId = temp,
                            ClientNo = customerClient.Id,
                            ClientName = customerClient.DescriptiveName
                        });
                    }
                    customerIdsToChildAccounts[managerCustomerId.Value].Add(customerClient);

                    if (customerClient.Manager)
                        if (!customerIdsToChildAccounts.ContainsKey(customerClient.Id) &&
                            customerClient.Level == 1)
                            unprocessedCustomerIds.Enqueue(customerClient.Id);
                }
            }
            var a = rootCustomerClient;
            //for(var i=0;i< customerIdsToChildAccounts.Count;i++){

            var b = customerIdsToChildAccounts;
            var c = 0;
        }
        return result;
    }
}
