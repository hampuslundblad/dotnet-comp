using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_comp.Clients
{
    private readonly HttpClient _httpClient;
    public class RunescapeClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<string?> GetPlayerHiscoreAsync(string name)
        {
            var url = $"m=hiscore_oldschool/index_lite.ws?player={name}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsBadRequestStatusCode)
            {
                throw new Exception("Player not found");
            }
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error fetching player data");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }