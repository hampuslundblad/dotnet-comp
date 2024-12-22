using dotnet_comp.Mappers;

using dotnet_comp.models;
using dotnet_comp.models.domain;
using Microsoft.OpenApi.Any;

namespace dotnet_comp.Services
{
    public class OsrsService
    {
        private readonly HttpClient _httpClient;

        public OsrsService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<PlayerHiscore> GetPlayerHiscoreDataAsync(string name)
        {

            var response = await _httpClient.GetAsync($"https://secure.runescape.com/m=hiscore_oldschool/index_lite.ws?player={name}");
            if (response.IsBadRequestStatusCode)
            {
                throw new Exception("Player not found");
            }
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error fetching player data");
            }

            var responseString = await response.Content.ReadAsStringAsync();

            var parts = responseString.Split([',', '\n'], StringSplitOptions.RemoveEmptyEntries);
            var skills = SkillMapper.MapStringToSkill(parts.Skip(3).ToArray());
            var playerRank = parts[0];
            var totalLevel = parts[1];
            var totalExperience = parts[2];

            return new PlayerHiscore()
            {
                Name = name,
                TotalExperience = int.Parse(totalExperience),
                Rank = int.Parse(playerRank),
                TotalLevel = int.Parse(totalLevel),
                Skills = skills,
            };
        }
    }
}