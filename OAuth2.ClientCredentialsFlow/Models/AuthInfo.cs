/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using Newtonsoft.Json;

namespace OAuth.ClientCredentialsFlow.Models
{
    public class AuthInfo
    {
        [JsonProperty("scope")]
        public string Scope { get; set; }
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        [JsonProperty("grant_type")]
        private string GrantType { get; set; }
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        public AuthInfo()
        {
            this.GrantType = "client_credentials";
        }
    }
}
