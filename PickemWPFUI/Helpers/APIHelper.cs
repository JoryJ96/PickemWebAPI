﻿using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;
using System.Configuration;

namespace PickemWPFUI.Helpers
{
    public class APIHelper
    {
        public HttpClient ApiClient { get; set; }

        private void InitializeClient()
        {
            string conn = ConfigurationManager.AppSettings["connectionString"];

            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri(conn);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            using (HttpResponseMessage response = await ApiClient.PostAsync("/Token", data))
            {

            }
        }
    }
}
