using System;

namespace Monad.Maybe
{
    public class Just<T> : IMaybe<T>
    {
        private T value;

        public bool HasValue => true;
        
        private Just(T value)
        {
            this.value = value;
        }
        
        public static IMaybe<T> Of(T value)
        {
            return new Just<T>(value);
        }

        public void IfHasValue(Action<T> action)
        {
            Checker.Null<ArgumentNullException>(action);
            action.Invoke(value);
        }

        public IMaybe<TResult> Bind<TResult>(Func<T, TResult> function)
        {
            Checker.Null<ArgumentNullException>(function);
            return Maybe<TResult>.Of(function.Invoke(value));
        }

        public IMaybe<TResult> Bind<TResult>(Func<T, IMaybe<TResult>> function)
        {
            Checker.Null<ArgumentNullException>(function);
            throw new NotImplementedException();
        }

        public T ValueOr(T result)
        {
            return value;
        }

        public T ValueOr(Func<T> function)
        {
            Checker.Null<ArgumentNullException>(function);
            return value;
        }
    }
}