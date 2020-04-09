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
            return None<TResult>.Of();
        }

        public IMaybe<TResult> Bind<TResult>(Func<T, IMaybe<TResult>> function)
        {
            Checker.Null<ArgumentNullException>(function);
            return None<TResult>.Of();
        }

        public T ValueOr(T result)
        {
            return result;
        }

        public T ValueOr(Func<T> function)
        {
            Checker.Null<ArgumentNullException>(function);

            return function.Invoke();
        }

        public static IMaybe<T> Of()
        {
            return new None<T>();
        }
    }
}