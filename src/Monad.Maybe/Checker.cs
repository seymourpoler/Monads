using System;

namespace Monad.Maybe
{
    public class Checker
    {
        public static void Null<TException, T>(T value)
        {
            if (value is null)
            {
                throw new NotImplementedException();
            }
        } 
    }
}