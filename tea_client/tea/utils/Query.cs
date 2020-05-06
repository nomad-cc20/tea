using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace tea.utils
{
    class Query
    {
        private static String PREFIX = "localhost:8080/toychange/";
        private static HttpClient client = new HttpClient();

        private static String GetPath(String postfix)
        {
            return PREFIX + postfix;
        }

        static async Task<List<Offer>> GetAllOffers()
        {
            List<Offer> offers = null;
            HttpResponseMessage response = await client.GetAsync(GetPath("getAllOffers"));
            if (response.IsSuccessStatusCode)
            {
                offers = await response.Content.ReadAsAsync<List<Offer>>();
            }
            return offers;
        }
    }
}
