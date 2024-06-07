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

        private const string API_URL = "https://newsapi.org/v2/everything?q=amazon&from=2024-06-06&to=2024-06-06&sortBy=popularity&apiKey=b4948be7f1874e189b9a03e942079bb9";

        public NYTimesApiIntegration(ILogger<NYTimesApiIntegration> logger)
        {
            _logger = logger;
        }

        public async Task<List<Article>> GetNews(String query)
        {

            var url = "https://newsapi.org/v2/everything?q=apple&from=2024-06-06&to=2024-06-06&sortBy=popularity&apiKey=b4948be7f1874e189b9a03e942079bb9";

            using (var client = new WebClient())
            {

                var json = await client.DownloadStringTaskAsync(url);
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json);
                return apiResponse.Articles;
            }
        }
    }

}





