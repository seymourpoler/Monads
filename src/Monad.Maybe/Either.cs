using System;

namespace Monad.Maybe;

public sealed class Either<TError, TSuccess>
{
    private TSuccess success;
    
    private Either(TSuccess success)
    {
        this.success = success;
    }
    
    public static Either<TError, TSuccess>  Success(TSuccess success)
    {
        return new Either<TError, TSuccess>(success);
    }
    
    public Either<TError, TOtherSuccess> Bind<TOtherSuccess>(Func<TSuccess,Either<TError, TOtherSuccess>> onSuccess)
    {
        Checker.Null<ArgumentNullException>(onSuccess);
        
        return onSuccess(success);
    }
}