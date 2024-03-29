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
    public void throw_exception_when_binding_a_success_either_with_a_function_is_null()
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
        var wasExecuted = false;
        Func<Success, Either<Error, OtherSuccess>> onSuccess = _ =>
        {
            wasExecuted = true;
            return Either<Error, OtherSuccess>.Success(new OtherSuccess());
        };

        var result = successEither.Bind(onSuccess);

        result.ShouldBeOfType<Either<Error, OtherSuccess>>();
        wasExecuted.ShouldBeTrue();
    }
    
    [Fact]
    public void throw_exception_when_mapping_a_success_either_with_a_function_is_null()
    {
        var successEither = Either<Error, Success>.Success(new Success());
        Func<Success, Thing> onSuccess = null;
        Func<Error, Thing> onError = _ => new Thing();
        
        var action = () => { successEither.Map(onSuccess, onError); };

        action.ShouldThrow<ArgumentNullException>();
        
    }
    
    [Fact]
    public void map_a_success_either_with_a_function()
    {
        var successEither = Either<Error, Success>.Success(new Success());
        var wasExecuted = false;
        Func<Success, Thing> onSuccess = _ =>
        {
            wasExecuted = true;
            return new Thing();
        };
        
        var result = successEither.Map(onSuccess, null);

        result.ShouldBeOfType<Thing>();
        wasExecuted.ShouldBeTrue();

    }
    
    [Fact]
    public void create_an_error_either()
    {
        var result = Either<Error, Success>.Error(new Error());
        
        result.ShouldBeOfType<Either<Error, Success>>();
    }
    
    [Fact]
    public void throw_exception_when_binding_an_error_either_with_a_function_is_null()
    {
        var errorEither = Either<Error, Success>.Error(new Error());
        Func<Success, Either<Error, OtherSuccess>> onSuccess = null;
        
        var action = () => { errorEither.Bind(onSuccess); };

        action.ShouldThrow<ArgumentNullException>();
        
    }
    
    [Fact]
    public void return_error_either_when_binding_with_a_function()
    {
        var successEither = Either<Error, Success>.Error(new Error());
        var wasExecuted = false;
        Func<Success, Either<Error, OtherSuccess>> onError = _ =>
        {
            wasExecuted = true;
            return Either<Error, OtherSuccess>.Success(new OtherSuccess());
        };

        var result = successEither.Bind(onError);

        result.ShouldBeOfType<Either<Error, OtherSuccess>>();
        wasExecuted.ShouldBeFalse();
    }
    
    [Fact]
    public void throw_exception_when_mapping_a_error_either_with_a_function_is_null()
    {
        var successEither = Either<Error, Success>.Error(new Error());
        Func<Success, Thing> onSuccess = null;
        Func<Error, Thing> onError = null;
        
        var action = () => { successEither.Map(onSuccess, onError); };

        action.ShouldThrow<ArgumentNullException>();
        
    }
    
    [Fact]
    public void map_an_error_either_with_a_function()
    {
        var successEither = Either<Error, Success>.Error(new Error());
        var wasExecuted = false;
        Func<Success, Thing> onSuccess = null;
        Func<Error, Thing> onError = _ =>
        {
            wasExecuted = true;
            return new Thing();
        };
        
        var result = successEither.Map(onSuccess, onError);

        result.ShouldBeOfType<Thing>();
        wasExecuted.ShouldBeTrue();
    }
    
    class OtherSuccess {}
    class Success {}
    class Error {}
    class Thing{}
}