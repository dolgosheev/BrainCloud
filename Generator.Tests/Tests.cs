using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Generator.Tests
{
    public class Tests
    {
        private readonly Generator _sut;
        private readonly ITestOutputHelper output;

        public Tests(ITestOutputHelper output)
        {
            _sut = new Generator();
            this.output = output;
        }

        [Fact]
        public void LengthInclude()
        {
            var result = _sut.Generate(35);
            output.WriteLine(result);

            Assert.True(result.Length == 35);
        }

        [Fact]
        public void LengthExclude()
        {
            var result = _sut.Generate(35, false, false, false);
            output.WriteLine(result);

            Assert.True(string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        public void DigitsInclude()
        {
            var result = _sut.Generate(35);
            output.WriteLine(result);

            Assert.Contains(result, char.IsDigit);
        }

        [Fact]
        public void DigitsExclude()
        {
            var result = _sut.Generate(35, false);
            output.WriteLine(result);

            Assert.DoesNotContain(result, char.IsDigit);
        }

        [Fact]
        public void UpperCaseInclude()
        {
            var result = _sut.Generate(35);
            output.WriteLine(result);

            Assert.Contains(result, char.IsUpper);
        }

        [Fact]
        public void UpperCaseExclude()
        {
            var result = _sut.Generate(35, upperCase: false);
            output.WriteLine(result);

            Assert.DoesNotContain(result, char.IsUpper);
        }

        [Fact]
        public void LowerCaseInclude()
        {
            var result = _sut.Generate(35);
            output.WriteLine(result);

            Assert.Contains(result, char.IsLower);
        }

        [Fact]
        public void LowerCaseExclude()
        {
            var result = _sut.Generate(35, lowerCase: false);
            output.WriteLine(result);

            Assert.DoesNotContain(result, char.IsLower);
        }

        [Fact]
        public void SymbolsInclude()
        {
            var result = _sut.Generate(35, false, false, false, "!@#$%^&*()_+".ToArray());
            output.WriteLine(result);

            Assert.Contains(result, char.IsSymbol);
        }

        [Fact]
        public void SymbolsExclude()
        {
            var result = _sut.Generate(35);
            output.WriteLine(result);

            Assert.DoesNotContain(result, char.IsSymbol);
        }
    }
}