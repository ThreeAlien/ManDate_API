using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util.Store;

namespace mandate.Utility.Oauth;

/// <summary>
/// 產生使用者憑證
/// </summary>
public class GenerateUserCredentials
{
    /// <summary>
    /// The Google Ads API scope.
    /// </summary>
    private const string GOOGLE_ADS_API_SCOPE = "https://www.googleapis.com/auth/adwords";

    /// <summary>
    /// ClientID
    /// </summary>
    private const string ClientID = "732004983478-a26k8c3a5piuedeekitriknhcihirvtg.apps.googleusercontent.com";

    /// <summary>
    /// ClientSecret
    /// </summary>
    private const string ClientSecret = "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";


    /// <summary>
    /// 產生RefreshToken
    /// </summary>
    /// <returns></returns>
    public static string? GenerateRefreshToken()
    {
        string? refreshToken = null;
        ClientSecrets secrets = new()
        {
            ClientId = ClientID,
            ClientSecret = ClientSecret
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
                new string[] { GOOGLE_ADS_API_SCOPE },
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

        return refreshToken;
    }
}
