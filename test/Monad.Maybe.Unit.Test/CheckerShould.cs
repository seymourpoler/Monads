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
    }
}