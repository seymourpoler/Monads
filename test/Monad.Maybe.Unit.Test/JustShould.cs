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
    }
}