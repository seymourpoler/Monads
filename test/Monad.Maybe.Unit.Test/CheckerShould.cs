using System;
using Shouldly;
using Xunit;

namespace Monad.Maybe.Unit.Test
{
    public class CheckerShould
    {
        [Fact]
        public void throw_exception_when_is_null()
        {
            Action action = () => Checker.Null<ArgumentNullException, string>(null);

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void do_nothing_when_is_not_null()
        {
            Action action = () => Checker.Null<ArgumentNullException, string>("some value");

            action.ShouldNotThrow();
        }
    }
}