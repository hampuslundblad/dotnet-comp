using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DotnetComp.Errors
{
    public static class PlayerHiscoreError
    {
        public static BaseError NotFound()
        {
            return BaseError.Failure("PlayerHiscoreError.NotFound", "Player not found");
        }
        public static BaseError ServiceError()
        {
            return BaseError.Failure("PlayerHiscoreError.ServiceError", "Service error");
        }
        public static BaseError ConversionError()
        {
            return BaseError.Failure("PlayerHiscoreError.ConversionError", "Error when calculating player hiscore");
        }
    }
}