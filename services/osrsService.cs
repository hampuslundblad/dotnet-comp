using System.Net.Http;
using System.Threading.Tasks;

namespace dotnet_comp.Services
{
    public class OsrsService
    {
        private readonly HttpClient _httpClient;

        public OsrsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> GetHiscoreDataAsync(string name)
        {
            var response = await _httpClient.GetAsync($"https://secure.runescape.com/m=hiscore_oldschool/index_lite.ws?player={name}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }
    }
}