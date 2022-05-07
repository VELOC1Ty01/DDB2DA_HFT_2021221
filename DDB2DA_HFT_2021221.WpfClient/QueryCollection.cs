using DDB2DA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.WpfClient
{
    public class QueryCollection<T>
    {
        public string endpoint;

        public static HttpClient client;

        public static HttpResponseMessage response;

        public List<T> result;

        public QueryCollection(string endpoint)
        {
            this.endpoint = endpoint;

            client = new HttpClient();

            response = client.GetAsync("http://localhost:21304/Query/" + endpoint).Result;

            result = JsonSerializer.Deserialize<List<T>>
                (response.Content.ReadAsStringAsync().Result,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, });
        }
    }
}
