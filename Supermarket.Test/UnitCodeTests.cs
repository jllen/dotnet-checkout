using System.Text.RegularExpressions;

namespace Supermarket.Test
{
    public class UnitCodeTests
    {
        [Fact]
        public void Construct_throws_argument_exception_when_invalid_code()
        {
            var nonAlphaChars = CharAssistant.GetNonAlphaChars();
            
            foreach (var nonAlphaChar in nonAlphaChars)
            {
                Assert.Throws<ArgumentException>(() => new UnitCode(nonAlphaChar));
            }
        }

        [Fact]
        public void Sets_value() 
        { 
            var code = 'A';
            var unitCode = new UnitCode(code);
            Assert.Equal(code, unitCode.Value);
        }
    }
}
