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
        public void bind_without_optional_when_has_value()
        {
            var mayBe = Maybe<string>.Of("some value");
            
            var result = mayBe.Bind(x => x.Contains("some"));

            result.ShouldBeOfType<Maybe<bool>>();
        }

        [Fact]
        public void throws_exception_when_function_with_maybe_is_null()
        {
            var mayBe = Maybe<string>.Of("some value");
            Func<string, Maybe<bool>> function = null;
            
            Action action = () => { mayBe.Bind(function); };

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void bind_with_optional_when_has_value()
        {
            var mayBe = Maybe<string>.Of("some value");
            
            var result = mayBe.Bind(x => Maybe<bool>.Of(x.Contains("some")));

            result.ShouldBeOfType<Maybe<bool>>();
        }
        
        [Fact]
        public void return_value_when_has_value()
        {
            const string value = "some value";
            var mayBe = Maybe<string>.Of(value);

            var result = mayBe.ValueOr("another value");
            
            result.ShouldBe(value);
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