using System;

namespace Monad.Maybe
{
    public interface IMaybe<T>
    {
        IMaybe<TResult> Bind<TResult>(Func<T, IMaybe<TResult>> function);
        TResult Match<TResult>(Func<T, TResult> functionWithValue, Func<TResult> functionWithoutValue);
    }
}