using System;
using Shouldly;
using Xunit;

namespace Monad.Maybe.Unit.Test;

public class NoneShould
{
    [Fact]
    public void throw_exception_when_binding_with_a_function_which_is_null()
    {
        var mayBe = None<string>.Of();
        Func<string, IMaybe<bool>> function = null;

        var action = () => { mayBe.Bind(function); };

        action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void bind_with_optional_when_has_no_value()
    {
        var mayBe = None<string>.Of();

        var result = mayBe.Bind(x => None<User>.Of());

        result.ShouldBeOfType<None<User>>();
    }

    [Fact]
    public void throw_exception_when_function_without_maybe_is_null()
    {
        var mayBe = None<string>.Of();
        Func<string, IMaybe<bool>> function = null;
        var action = () => { mayBe.Bind(function); };

        action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void bind_without_optional_when_has_no_value()
    {
        var mayBe = None<string>.Of();

        var result = mayBe.Bind(x => None<User>.Of());

        result.ShouldBeOfType<None<User>>();
    }

    [Fact]
    public void throws_exception_when_mapping_with_a_function_which_is_null()
    {
        var mayBe = None<string>.Of();
        Func<string, string> functionWithValue = null;
        Func<string> functionWithoutValue = null;

        var action = () => { mayBe.Map<string>(value => value, null); };

        action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void mapping_with_a_function_which_is_null()
    {
        var mayBe = None<string>.Of();

        var result = mayBe.Map(null, () => true);

        result.ShouldBe(true);
    }
}