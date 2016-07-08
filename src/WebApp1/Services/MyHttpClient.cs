using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApp1.Services
{
    public static class MyHttpClient<T> where T : class
    {
        public static async Task<T> GetAsyncResponse(string url) 
        {
            using (var httpClient = new HttpClient()) {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var something = await response.Content.ReadAsStringAsync();
                    
                    return JsonConvert.DeserializeObject<T>(something);
                }

                return null;
            }
        }
    }
}