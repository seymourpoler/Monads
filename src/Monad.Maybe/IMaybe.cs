using System;

namespace Monad.Maybe
{
    public interface IMaybe<T>
    {
        bool HasValue { get; }
        void IfHasValue(Action<T> action);
        Maybe<TResult> Bind<TResult>(Func<T, TResult> function);
        Maybe<TResult> Bind<TResult>(Func<T, Maybe<TResult>> function);
        T ValueOr(T result);
        T ValueOr(Func<T> function);
    }
}