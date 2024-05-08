using Azure.Core;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace AzureSignToolClickOnce.Utils
{
    internal class AccessTokenCredential : TokenCredential
    {
        private readonly AccessToken accessToken;

        public AccessTokenCredential(string token, DateTimeOffset expiresOn)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("Access Token cannot be null or empty", nameof(token));
            }

            accessToken = new AccessToken(token, expiresOn);
        }

        public AccessTokenCredential(string token) : this(token, DateTimeOffset.UtcNow.AddHours(1))
        {

        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return accessToken;
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<AccessToken>(accessToken);
        }
    }
}