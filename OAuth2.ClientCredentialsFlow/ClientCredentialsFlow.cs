/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace OAuth.ClientCredentialsFlow.Models
{
    public class ClientCredentialsFlow
    {
        #region Fields
        private readonly string _authority;
        private readonly AuthInfo _authInfo;
        private readonly HttpClient _httpClient;
        #endregion

        #region Constructor
        public ClientCredentialsFlow(string authority, AuthInfo authInfo)
        {
            this._authInfo = authInfo;
            this._authority = authority;
            this._httpClient = new HttpClient();
        }
        #endregion

        #region Methods
        public async Task<AuthResponse> Authenticate()
        {
            if (_authInfo == null)
            {
                throw new NullReferenceException("NullReferenceException: authInfo must be not null !");
            }
            if (string.IsNullOrEmpty(_authInfo.ClientId))
            {
                throw new NullReferenceException("NullReferenceException: ClientId must be not null !");
            }
            if (string.IsNullOrEmpty(_authInfo.ClientSecret))
            {
                throw new NullReferenceException("NullReferenceException: ClientSecret must be not null !");
            }

            try
            {
                const string requestParam = "scope={0}&client_id={1}&grant_type=client_credentials&client_secret={2}";

                var payload = string.Format(requestParam,
                                WebUtility.UrlEncode(_authInfo.Scope),
                                WebUtility.UrlEncode(_authInfo.ClientId),
                                WebUtility.UrlEncode(_authInfo.ClientSecret));

                var content = new StringContent(payload, Encoding.UTF8, "application/x-www-form-urlencoded");
                using (var response = await _httpClient.PostAsync(_authority, content))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Status:  {0}", response.StatusCode);
                        Console.WriteLine("Content: {0}", await response.Content.ReadAsStringAsync());
                    }
                    response.EnsureSuccessStatusCode();

                    var responseAsString = await response.Content.ReadAsStringAsync();
                    var responseAsObject = JsonConvert.DeserializeObject<AuthResponse>(responseAsString);

                    return responseAsObject;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
