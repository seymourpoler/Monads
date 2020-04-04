using System;

namespace Monad.Maybe
{
    public class Checker
    {
        public static void Null<TException, T>(T value)
        {
            throw new NotImplementedException();
        } 
    }
}