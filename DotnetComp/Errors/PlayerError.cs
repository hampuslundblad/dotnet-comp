namespace DotnetComp.Errors
{
    public sealed class PlayerError(string code, string description) : IError
    {
        public string Code { get; set; } = code;

        public string Description { get; set; } = description;

        public static PlayerError NotFound()
        {
            return new PlayerError("Player.NotFound", "Player not found");
        }

        public static PlayerError ServiceError()
        {
            return new PlayerError("Player.ServiceError", "Service error");
        }

    }
}