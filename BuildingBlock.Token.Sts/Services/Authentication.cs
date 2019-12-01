using System;
using System.Threading.Tasks;
using BuildingBlock.Token.Sts.ExternalServices;
using BuildingBlock.Token.Sts.ExternalServices.Models;
using Microsoft.Extensions.Configuration;

namespace BuildingBlock.Token.Sts.Services
{
    public class Authentication : IAuthentication
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;

        public Authentication(IAuthenticationService authenticationService, IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _configuration = configuration;
        }

        public async Task<ExternalServices.Models.Token> GetToken()
        {
            var token = await _authenticationService.GetToken("673468086421.842446468050", "1420dbceba0022c17f04aefbbd0d758e","");

            if (token == null)
                throw new Exception("Invalid Token");

            return token;

        }
    }
}
