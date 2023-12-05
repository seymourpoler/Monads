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

        public TResult Match<TResult>(Func<T, TResult> functionWithValue, Func<TResult> functionWithoutValue)
        {
            Checker.Null<ArgumentNullException>(functionWithValue);

            return functionWithValue.Invoke(value);
        }
    }
}