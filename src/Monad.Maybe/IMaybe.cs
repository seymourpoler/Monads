using System;

namespace Monad.Maybe;

public interface IMaybe<T>
{
    IMaybe<TResult> Bind<TResult>(Func<T, IMaybe<TResult>> function);
    TResult Map<TResult>(Func<T, TResult> onWithValue, Func<TResult> onWithoutValue);
}