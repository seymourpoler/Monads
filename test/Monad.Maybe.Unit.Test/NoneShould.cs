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
            var mayBe = None<string>.Of();

            mayBe.HasValue.ShouldBeFalse();
        }
        
        [Fact]
        public void throw_exception_when_if_has_value()
        {
            var mayBe = None<string>.Of();

            Action action = () => mayBe.IfHasValue(null);

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void not_execute_if_has_no_value()
        {
            var executed = false;
            var mayBe = None<string>.Of();

            mayBe.IfHasValue(x => executed = true);
            
            executed.ShouldBeFalse();
        }
        
        [Fact]
        public void throws_exception_when_function_with_maybe_is_null()
        {
            var mayBe = None<string>.Of();
            Func<string, IMaybe<bool>> function = null;
            
            Action action = () => { mayBe.Bind(function); };

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void bind_with_optional_when_has_no_value()
        {
            var mayBe = None<string>.Of();
            
            var result = mayBe.Bind(x =>  Maybe<User>.Of(new User()));

            result.ShouldBeOfType<None<User>>();
            result.HasValue.ShouldBeFalse();
        }
        
        [Fact]
        public void throws_exception_when_function_without_maybe_is_null()
        {
            var mayBe = None<string>.Of();
            Func<string, bool> function = null;
            Action action = () => { mayBe.Bind(function); };

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void bind_without_optional_when_has_no_value()
        {
            var mayBe = None<string>.Of();
            
            var result = mayBe.Bind(x => new User());

            result.ShouldBeOfType<None<User>>();
            result.HasValue.ShouldBeFalse();
        }
        
        [Fact]
        public void throw_exception_when_function_is_null()
        {
            var mayBe = None<string>.Of();
            Func<string> function = null;

            Action action = () => mayBe.ValueOr(function);

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void return_value_from_function()
        {
            const string value = "some thing";
            var mayBe = None<string>.Of();

            var result = mayBe.ValueOr(() => value);
            
            result.ShouldBe(value);
        }
        
        [Fact]
        public void return_parameter_as_value()
        {
            const string value = "some value";
            var mayBe = None<string>.Of();
    
            var result = mayBe.ValueOr(value);
            
            result.ShouldBe(value);
        }
    }
}