using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DotnetComp.Errors
{
    public sealed class PlayerHiscoreError(string code, string description) : IError
    {
        public string Code { get; set; } = code;

        public string Description { get; set; } = description;

        public static PlayerHiscoreError NotFound()
        {
            return new PlayerHiscoreError("PlayerHiscoreError.NotFound", "Player not found");
        }
        public static PlayerHiscoreError ServiceError()
        {
            return new PlayerHiscoreError("PlayerHiscoreError.ServiceError", "Service error");
        }
        public static PlayerHiscoreError ConversionError()
        {
            return new PlayerHiscoreError("PlayerHiscoreError.ConversionError", "Error when calculating player hiscore");
        }
    }
}