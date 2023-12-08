using System;
using Shouldly;
using Xunit;

namespace Monad.Maybe.Unit.Test;

public class EitherShould
{
    [Fact]
    public void create_a_success_either()
    {
        var result = Either<Error, Success>.Success(new Success());
        
        result.ShouldBeOfType<Either<Error, Success>>();
    }
    
    [Fact]
    public void throw_exception_when_binding_with_a_function_is_null()
    {
        var successEither = Either<Error, Success>.Success(new Success());
        Func<Success, Either<Error, OtherSuccess>> onSuccess = null;
        
        var action = () => { successEither.Bind(onSuccess); };

        action.ShouldThrow<ArgumentNullException>();
        
    }
    
    [Fact]
    public void return_other_success_either_when_binding_with_a_function()
    {
        var successEither = Either<Error, Success>.Success(new Success());
        Func<Success, Either<Error, OtherSuccess>> onSuccess = _ => Either<Error, OtherSuccess>.Success(new OtherSuccess());

        var result = successEither.Bind(onSuccess);

        result.ShouldBeOfType<Either<Error, OtherSuccess>>();
    }
    
    [Fact]
    public void create_an_error_either()
    {
        var result = Either<Error, Success>.Error(new Error());
        
        result.ShouldBeOfType<Either<Error, Success>>();
    }
    
    
    class OtherSuccess {}
    class Success {}
    class Error {}
    
}