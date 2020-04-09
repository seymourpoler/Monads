using System;

namespace Monad.Maybe
{
    public class None<T> : IMaybe<T>
    {
        public bool HasValue => false;

        private None()
        {
            
        }

        public void IfHasValue(Action<T> action)
        {
            Checker.Null<ArgumentNullException>(action);
        }

        public IMaybe<TResult> Bind<TResult>(Func<T, TResult> function)
        {
            Checker.Null<ArgumentNullException>(function);
            
            throw new NotImplementedException();
        }

        public IMaybe<TResult> Bind<TResult>(Func<T, IMaybe<TResult>> function)
        {
            Checker.Null<ArgumentNullException>(function);
            return None<TResult>.Of(default);
        }

        public T ValueOr(T result)
        {
            throw new NotImplementedException();
        }

        public T ValueOr(Func<T> function)
        {
            throw new NotImplementedException();
        }

        public static IMaybe<T> Of(T value)
        {
            return new None<T>();
        }
    }
}