using System;

namespace Monad.Maybe
{
    public static class Checker
    {
        public static void Null<TException>(object value) where TException: Exception
        {
            if (value is null)
            {
                throw (TException)Activator.CreateInstance(typeof(TException));
            }
        } 
    }
}