namespace Monad.Maybe
{
    public class None
    {
        [Fact]
        public void return_false_when_has_no_value()
        {
            var mayBe = Maybe<string>.Of(null);

            mayBe.HasValue.ShouldBeFalse();
        }
    }
}