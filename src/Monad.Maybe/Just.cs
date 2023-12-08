using System;

namespace Monad.Maybe
{
    public class Just<T> : IMaybe<T>
    {
        private T value;
        
        private Just(T value)
        {
            this.value = value;
        }
        
        public static IMaybe<T> Of(T value)
        {
            return new Just<T>(value);
        }

        public IMaybe<TResult> Bind<TResult>(Func<T, IMaybe<TResult>> function)
        {
            Checker.Null<ArgumentNullException>(function);
            
            return function.Invoke(value);
        }

        public TResult Map<TResult>(Func<T, TResult> onWithValue, Func<TResult> onWithoutValue)
        {
            Checker.Null<ArgumentNullException>(onWithValue);

            return onWithValue.Invoke(value);
        }
    }
}