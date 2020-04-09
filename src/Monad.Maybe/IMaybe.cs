using System;

namespace Monad.Maybe
{
    public interface IMaybe<T>
    {
        bool HasValue { get; }
        void IfHasValue(Action<T> action);
        IMaybe<TResult> Bind<TResult>(Func<T, TResult> function);
        IMaybe<TResult> Bind<TResult>(Func<T, IMaybe<TResult>> function);
        T ValueOr(T result);
        T ValueOr(Func<T> function);
    }
}