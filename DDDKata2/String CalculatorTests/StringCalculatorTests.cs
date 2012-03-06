using System;
using DDDKata2;
using Xunit;

namespace String_CalculatorTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void GivenAnEmptyStringShouldReturnZero()
        {
            "".ShouldCalc(0);
        }

        [Fact]
        public void GivenASingleNumberShouldReturnNumber()
        {
            "1".ShouldCalc(1);
        }
        
        [Fact]
        public void GivenTwoNumbersShouldReturnTheSumOfBoth()
        {
            "1,2".ShouldCalc(3);
        }

        [Fact]
        public void GivenMultipleNumbersShouldReturnTheSumOfAllNumbers()
        {
            "1,2,3".ShouldCalc(6);
        }

        [Fact]
        public void GivenNewLineAsADelimeterShouldReturnSumOfAllNumbers()
        {
            "1\n2\n3".ShouldCalc(6);
        }

        [Fact]
        public void GivenConsecutiveDelimetersShouldThrowException()
        {
            Assert.Throws(typeof(ArgumentException), () => ",,".ShouldCalc(-1));
        }

        [Fact]
        public void GivenACustomerDelimeterDefinitionShouldReturnTheSumOfNumbers()
        {
            "//:1:2:3".ShouldCalc(6);
        }
        
        [Fact]
        public void GivenANegativeNumberShouldThrowAnExecption()
        {
            Assert.Throws(typeof(ArgumentException), () => "1,-1".ShouldCalc(-1));
        }

        [Fact]
        public void NegativeNumbersErrorMessageShouldContainNegativeNumber()
        {
            var error = Assert.Throws(typeof(ArgumentException), () => "1,-1".ShouldCalc(-1));
            Assert.True(error.Message.Contains("-1"));
        }

    }


    public static class TestHelper
    {
        public static void ShouldCalc(this string input, int expected)
        {
            var item = new StringCalculator(null);
            Assert.Equal(expected, item.Add(input));
        }

    }
}
