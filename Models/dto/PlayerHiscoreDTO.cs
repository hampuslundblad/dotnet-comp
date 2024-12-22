namespace dotnet_comp.models
{
    public class PlayerHiscoreDTO
    {
        public required string Name { get; set; }
        public required int Rank { get; set; }
        public required Skill[] Skills { get; set; }
        public required int TotalExperience { get; set; }
        public required int TotalLevel { get; set; }
    }
}