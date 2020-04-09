using System;
using Shouldly;
using Xunit;

namespace Monad.Maybe.Unit.Test
{
    public class NoneShould
    {
        [Fact]
        public void return_false_when_has_no_value()
        {
            var mayBe = None<string>.Of(null);

            mayBe.HasValue.ShouldBeFalse();
        }
        
        [Fact]
        public void throw_exception_when_if_has_value()
        {
            var mayBe = None<string>.Of(null);

            Action action = () => mayBe.IfHasValue(null);

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void not_execute_if_has_no_value()
        {
            var executed = false;
            var mayBe = None<string>.Of(null);

            mayBe.IfHasValue(x => executed = true);
            
            executed.ShouldBeFalse();
        }
    }
}