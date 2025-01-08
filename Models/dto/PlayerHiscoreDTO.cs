using dotnet_comp.Models.Domain;
namespace dotnet_comp.Models.Dto
{
    public class PlayerHiscoreDTO
    {
        public required string Name { get; set; }
        public required int Rank { get; set; }
        public required List<Skill> Skills { get; set; }
        public required int TotalExperience { get; set; }
        public required int TotalLevel { get; set; }

        public static PlayerHiscoreDTO FromDomain(PlayerHiscore domain)
        {
            var dto = new PlayerHiscoreDTO
            {

                Name = domain.Name,
                Rank = domain.Rank,
                Skills = domain.Skills,
                TotalExperience = domain.TotalExperience,
                TotalLevel = domain.TotalLevel,
            };
            return dto;
        }
    }

}