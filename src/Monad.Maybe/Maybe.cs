using System;

namespace Monad.Maybe
{
    public class Maybe<T>
    {
        private readonly T value;

        public bool HasValue => value != null;

        public static Maybe<T> None => new Maybe<T>(default(T));

        private Maybe(T value)
        {
            this.value = value;
        }
        
        public static Maybe<T> Of(T value)
        {
            return new Maybe<T>(value);
        }

        public void IfHasValue(Action<T> action)
        {
            if (action is null)
            {
                throw new ArgumentNullException();
            }
            if (HasValue){
                action(value);
            }
        }
        
        public Maybe<TResult> Bind<TResult>(Func<T, TResult> function)
        {
            if (function is null)
            {
                throw new ArgumentNullException();
            }

            if (HasValue)
            {
                return Maybe<TResult>.Of(
                    function.Invoke(value));    
            }

            return Maybe<TResult>.None;
        }

        public Maybe<TResult> Bind<TResult>(Func<T, Maybe<TResult>> function)
        {
            if (function is null)
            {
                throw new ArgumentNullException();
            }

            if (HasValue)
            {
                return function.Invoke(value);
            }
            return Maybe<TResult>.None;
        }

        public T ValueOr(T result)
        {
            if (HasValue)
            {
                return value;    
            }

            return result;
        }

        public T ValueOr(Func<T> function)
        {
            if (function is null)
            {
                throw new ArgumentNullException();
            }
            
            if(HasValue){
                return value;
            }

            return function.Invoke();
        }
    }
}