using System;

namespace Monad.Maybe
{
    public class Maybe<T> : IMaybe<T>
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
            Checker.Null<ArgumentNullException>(action);
            
            if (HasValue)
            {
                action(value);
            }
        }
        
        public Maybe<TResult> Bind<TResult>(Func<T, TResult> function)
        {
            Checker.Null<ArgumentNullException>(function);

            if (HasValue)
            {
                return Maybe<TResult>.Of(
                    function.Invoke(value));    
            }

            return Maybe<TResult>.None;
        }

        public Maybe<TResult> Bind<TResult>(Func<T, Maybe<TResult>> function)
        {
            Checker.Null<ArgumentNullException>(function);

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
            Checker.Null<ArgumentNullException>(function);
            
            if(HasValue){
                return value;
            }

            return function.Invoke();
        }
    }
}