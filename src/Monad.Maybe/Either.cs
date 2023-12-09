using System;

namespace Monad.Maybe;

public sealed class Either<TError, TSuccess>
{
    private TSuccess success;
    private TError error;
    
    private Either(TSuccess success)
    {
        this.success = success;
    }
    
    private Either(TError error)
    {
        this.error = error;
    }
    
    public static Either<TError, TSuccess>  Success(TSuccess success)
    {
        return new Either<TError, TSuccess>(success);
    }
    
    public static Either<TError, TSuccess>  Error(TError error)
    {
        return new Either<TError, TSuccess>(error);
    }
    
    public Either<TError, TOtherSuccess> Bind<TOtherSuccess>(Func<TSuccess,Either<TError, TOtherSuccess>> onSuccess)
    {
        Checker.Null<ArgumentNullException>(onSuccess);
        if(success is null) 
                return Either<TError, TOtherSuccess>.Error(error);
        return onSuccess(success);
    }

    public TResult Map<TResult>(Func<TSuccess,TResult> onSuccess)
    {
        Checker.Null<ArgumentNullException>(onSuccess);

        return onSuccess(success);
    }
}