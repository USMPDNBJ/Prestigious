using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;

namespace Prestigious.Integration.nytimes
{
    public class NYTimesApiIntegration
    {
        private readonly ILogger<NYTimesApiIntegration> _logger;

        private const string API_URL = "https://newsapi.org/v2/everything?from=2024-06-01&to=2024-06-11&apiKey=0c49226bbdb8482fbe9829e2e1299a18&sortBy=popularity&language=es&q=";

        public NYTimesApiIntegration(ILogger<NYTimesApiIntegration> logger)
        {
            _logger = logger;
        }

        public async Task<List<Article>> GetNews(String query)
        {

            var url = $"{API_URL}{query}";
            List<Article> filtro = new List<Article>();

            using (var client = new WebClient())
            {
                var json = await client.DownloadStringTaskAsync(url);
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json);
                filtro=apiResponse.Articles.ToList();

                    foreach (var item in filtro.ToList()){
                        if (item.UrlToImage==null){
                            filtro.Remove(item);
                        }
                    }
                return filtro;
            }
        }
    }

}





