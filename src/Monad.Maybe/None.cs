using System;

namespace Monad.Maybe
{
    public class None<T> : IMaybe<T>
    {
        public static IMaybe<T> Of()
        {
            return new None<T>();
        }

        public IMaybe<TResult> Bind<TResult>(Func<T, IMaybe<TResult>> function)
        {
            Checker.Null<ArgumentNullException>(function);
            
            return None<TResult>.Of();
        }

        public TResult Match<TResult>(Func<T, TResult> functionWithValue, Func<TResult> functionWithoutValue)
        {
            Checker.Null<ArgumentNullException>(functionWithoutValue);
            
            return functionWithoutValue.Invoke();
        }
    }
}