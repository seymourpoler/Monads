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
    }
}