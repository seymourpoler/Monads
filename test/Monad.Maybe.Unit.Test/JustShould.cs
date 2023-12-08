using System;
using Shouldly;
using Xunit;

namespace Monad.Maybe.Unit.Test
{
    public class JustShould
    {
        [Fact]
        public void throws_exception_when_function__is_null()
        {
            var mayBe = Just<string>.Of("some value");
            Func<string, IMaybe<bool>> function = null;
            
            var action = () => { mayBe.Bind(function); };

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void bind_with_value()
        {
            var mayBe = Just<string>.Of("some value");
            
            var result = mayBe.Bind<bool>(x => Maybe<bool>.Of( x.Contains("some")));
    
            result.ShouldBeOfType<Just<bool>>();
        }
        
        [Fact]
        public void throw_exception_when_mapping_with_null_function()
        {
            var mayBe = Just<string>.Of("some value");
            Func<string, bool> function = null;

            var action = () => { mayBe.Map(function, null); };

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void return_value_in_Mapping()
        {
            var mayBe = Just<string>.Of("some value");
            Func<string, bool> function = (value) => value.Contains("some");
            
            var result = mayBe.Map(function, null);

            result.ShouldBeTrue();
        }
    }
}