using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlock.Token.Sts.ExternalServices.Models;
using BuildingBlock.Token.Sts.Services;
using Microsoft.Extensions.Configuration;

namespace BuildingBlock.Token.Sts.HttpMessageHandler
{
    public class AuthorizationHandler : DelegatingHandler
    {
        private readonly IAuthentication _authentication;
        private readonly IConfiguration _configuration;
        public OAuthSettings OAuthSettings { get; private set; }

        public AuthorizationHandler(IAuthentication authentication, IConfiguration configuration)
        {
            _authentication = authentication;
            _configuration = configuration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            OAuthSettings = new OAuthSettings(
    clientId: "673468086421.842446468050",
    clientSecret: "1420dbceba0022c17f04aefbbd0d758e",
    scope: "channels:read chat:write:user",
    authorizeUrl: "https://slack.com/oauth/authorize",
    redirectUrl: "http://remediosdemaispodcast.com.br/",
    accessTokenUrl: "https://slack.com/api/oauth.access");

            var auth = request.Headers.Authorization;

            if (auth != null)
            {
                var _token = await _authentication.GetToken();

                if (string.IsNullOrEmpty(_token.AccessToken)) throw new ArgumentNullException("token is null or empty");


                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, jwt.AccessToken);
                
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
