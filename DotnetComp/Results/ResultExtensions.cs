using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetComp.Errors;

namespace DotnetComp.Results
{
    public static class ResultExtensions
    {
        public static T Match<T>(
            this BaseResult result,
            Func<T> onSuccess,
            Func<IError, T> onFailure)
        {
            return result.IsSucess ? onSuccess() : onFailure(result.Error!);
        }
        public static T Match<T, TValue>(
            this Result<TValue> result,
            Func<TValue, T> onSuccess,
            Func<IError, T> onFailure)
        {
            return result.IsSucess ? onSuccess(result.Value) : onFailure(result.Error!);
        }
    }
}