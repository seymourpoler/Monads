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

        public TResult Map<TResult>(Func<T, TResult> onWithValue, Func<TResult> onWithoutValue)
        {
            Checker.Null<ArgumentNullException>(onWithoutValue);
            
            return onWithoutValue.Invoke();
        }
    }
}