using System;
using Shouldly;
using Xunit;

namespace Monad.Maybe.Unit.Test
{
    public partial class MaybeShould
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

            result.ShouldBeOfType<Maybe<string>>();
        }

        [Fact]
        public void return_value_when_is_not_none()
        {
            const string value = "some thing";
            var mayBe = Maybe<string>.Of(value);

            var result = mayBe.ValueOr(() => "another value");
            
            result.ShouldBe(value);
        }
    }
}