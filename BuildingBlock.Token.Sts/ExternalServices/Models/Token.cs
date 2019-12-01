using Newtonsoft.Json;

namespace BuildingBlock.Token.Sts.ExternalServices.Models
{
    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("scope")]
        public int Scope { get; set; }

        [JsonProperty("team_id")]
        public string Team_id { get; set; }

        [JsonProperty("ok")]
        public string Ok { get; set; }
    }
}
