using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Util.Store;

namespace mandate.Business.Service;

public class DsAuthorizationBroker : GoogleWebAuthorizationBroker
{
    public static string RedirectUri;

    public static new async Task<UserCredential> AuthorizeAsync(
        ClientSecrets clientSecrets,
        IEnumerable<string> scopes,
        string user,
        CancellationToken taskCancellationToken,
        IDataStore dataStore = null)
    {
        GoogleAuthorizationCodeFlow.Initializer initializer = new GoogleAuthorizationCodeFlow.Initializer
        {
            ClientSecrets = clientSecrets,
        };

        return await AuthorizeAsyncCore(initializer, scopes, user,
            taskCancellationToken, dataStore).ConfigureAwait(false);
    }

    private static async Task<UserCredential> AuthorizeAsyncCore(
        GoogleAuthorizationCodeFlow.Initializer initializer,
        IEnumerable<string> scopes,
        string user,
        CancellationToken taskCancellationToken,
        IDataStore dataStore)
    {
        initializer.Scopes = scopes;
        initializer.DataStore = dataStore ?? new FileDataStore(Folder);
        DsAuthorizationCodeFlow flow = new(initializer);
        return await new AuthorizationCodeInstalledApp(flow,
            new LocalServerCodeReceiver())
            .AuthorizeAsync(user, taskCancellationToken).ConfigureAwait(false);
    }
}


public class DsAuthorizationCodeFlow : GoogleAuthorizationCodeFlow
{
    public DsAuthorizationCodeFlow(Initializer initializer)
        : base(initializer) { }

    public override AuthorizationCodeRequestUrl
                   CreateAuthorizationCodeRequest(string redirectUri)
    {
        return base.CreateAuthorizationCodeRequest(DsAuthorizationBroker.RedirectUri);
    }
}
