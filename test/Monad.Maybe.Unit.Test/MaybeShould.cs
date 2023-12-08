using Shouldly;
using Xunit;

namespace Monad.Maybe.Unit.Test;

public class MaybeShould
{
    [Fact]
    public void return_maybe_with_null_from_static_factory()
    {
        var result = Maybe<string>.Of(null);

        result.ShouldBeOfType<None<string>>();
    }

    [Fact]
    public void return_maybe_with_value_from_static_factory()
    {
        var result = Maybe<string>.Of("some value");

        result.ShouldBeOfType<Just<string>>();
    }
}