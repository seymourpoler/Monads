using System;
using Shouldly;
using Xunit;

namespace Monad.Maybe.Unit.Test
{
    public class JustShould
    {
        [Fact]
        public void return_true_when_has_value()
        {
            var mayBe = Just<string>.Of("some value");

            mayBe.HasValue.ShouldBeTrue();
        }
        
        [Fact]
        public void throw_exception_when_function_is_null_if_has_value()
        {
            var mayBe = Just<string>.Of("some value");

            Action action = () => mayBe.IfHasValue(null);

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void execute_if_has_value()
        {
            var executed = false;
            var mayBe = Just<string>.Of("some value");

            mayBe.IfHasValue(x => executed = true);
            
            executed.ShouldBeTrue();
        }
        
        [Fact]
        public void throws_exception_when_function_without_maybe_is_null()
        {
            var mayBe = Just<string>.Of("some value");
            Func<string, bool> function = null;
            Action action = () => { mayBe.Bind(function); };

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void bind_without_optional()
        {
            var mayBe = Just<string>.Of("some value");
            
            var result = mayBe.Bind(x => x.Contains("some"));
    
            result.ShouldBeOfType<Just<bool>>();
        }
        
        [Fact]
        public void return_value_when_has_value()
        {
            const string value = "some value";
            var mayBe = Just<string>.Of(value);

            var result = mayBe.ValueOr("another value");
            
            result.ShouldBe(value);
        }
        
        [Fact]
        public void return_value_from_function()
        {
            const string value = "some thing";
            var mayBe = Maybe<string>.Of(value);

            var result = mayBe.ValueOr(() => "another value");
            
            result.ShouldBe(value);
        }
    }
}