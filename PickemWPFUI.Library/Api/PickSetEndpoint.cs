using PickemWPFUI.Helpers;
using PickemWPFUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PickemWPFUI.Library.Api
{
    public class PickSetEndpoint : IPickSetEndpoint
    {
        private IAPIHelper _apiHelper;

        public PickSetEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task PostPickSet(PickSetModel set)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/PickSet", set))
            {
                if (response.IsSuccessStatusCode) { return; }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
