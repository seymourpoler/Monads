using System;

namespace Monad.Maybe
{
    public class Checker
    {
        public static void Null<TException, T>(T value) where TException: Exception
        {
            if (value is null)
            {
                throw (TException)Activator.CreateInstance(typeof(TException));
            }
        } 
    }
}