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
        public IError? Error { get; }

        //public static implicit operator BaseResult(IError error) => new(error);

        public static BaseResult Success() => new();

        public static BaseResult Failure(IError error) => new(error);

        protected BaseResult()
        {
            IsSucess = true;
            Error = default;
        }

        protected BaseResult(IError error)
        {
            IsSucess = false;
            Error = error;
        }


    }

}