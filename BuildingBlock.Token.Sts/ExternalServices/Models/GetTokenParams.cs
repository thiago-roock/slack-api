using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlock.Token.Sts.ExternalServices.Models
{
    public class GetTokenParams
    {
        [AliasAs("client_id")]
        public string ClientId { get; set; }
        [AliasAs("client_secret")]
        public string ClientSecret { get; set; }
    }
}
