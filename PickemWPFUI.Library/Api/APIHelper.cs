using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;
using System.Configuration;
using PickemWPFUI.Models;
using PickemWPFUI.Library.Models;

namespace PickemWPFUI.Helpers
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient _apiClient { get; set; }
        private ILoggedInUserModel _loggedInUser { get; set; }

        public HttpClient ApiClient {
            get {  return _apiClient; }
        }

        public APIHelper(ILoggedInUserModel loggedInUser)
        {
            InitializeClient();
            _loggedInUser = loggedInUser;
        }

        private void InitializeClient()
        {
            string conn = ConfigurationManager.AppSettings["connectionString"];

            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(conn);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }

        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            using (HttpResponseMessage response = await _apiClient.PostAsync("api/Token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task GetLoggedInUserInfo(string token)
        {
            _apiClient.DefaultRequestHeaders.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiClient.DefaultRequestHeaders.Add("Authorization", $"bearer { token }");

            using (HttpResponseMessage response = await _apiClient.GetAsync("/api/User"))
            {
                if ( response.IsSuccessStatusCode )
                {
                    var result = await response.Content.ReadAsAsync<LoggedInUserModel>();

                    _loggedInUser.Id = result.Id;
                    _loggedInUser.Name = result.Name;
                    _loggedInUser.Wins = result.Wins;
                    _loggedInUser.Losses = result.Losses;
                    _loggedInUser.Rank = result.Rank;

                    if (result.EmailAddress != null)
                    {
                        _loggedInUser.EmailAddress = result.EmailAddress;
                    }

                    if (result.PhoneNumber != null)
                    {
                        _loggedInUser.PhoneNumber = result.PhoneNumber;
                    }
                }
            }
        }
    }
}
