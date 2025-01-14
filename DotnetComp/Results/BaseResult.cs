using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetComp.Errors;

namespace DotnetComp.Results
{
    public class BaseResult
    {
        public bool IsSucess { get; protected set; }
        public BaseError? Error { get; }

        public static implicit operator BaseResult(BaseError error) => new(error);

        public static BaseResult Success() => new();

        public static BaseResult Failure(BaseError error) => new(error);

        protected BaseResult()
        {
            IsSucess = true;
            Error = default;
        }

        protected BaseResult(BaseError error)
        {
            IsSucess = false;
            Error = error;
        }
    }
}
