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
    }
}