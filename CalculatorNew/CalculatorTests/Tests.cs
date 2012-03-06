using System;
using CalculatorNew;
using Xunit;


namespace CalculatorTests
{

    public class Tests
    {
        [Fact]
        public void GivenEmptyStringReturnZero()
        {
            var cal = new StringCalculator();
            Assert.Equal(0, cal.Add(""));
        }

        [Fact]
        public void GivenSingleNumberReturn()
        {
            "1".ShoulEqual(1);
        }
        
        [Fact]
        public void GivenTwoNumbersReturnSum()
        {
            "1,2".ShoulEqual(3);
        }

        [Fact]
        public void GivenMultipleNumbersReturnSum()
        {
            "1,2,3".ShoulEqual(6);
        }

        [Fact]
        public void GivenNewLineDelReturnSum()
        {
            "1,2\n3".ShoulEqual(6);
        }

        [Fact]
        public void GivenEmptyStringReturnSum()
        {
            "1,\n2\n3".ShoulEqual(6);
        }

        [Fact]
        public void GivenCustomDelReturnSum()
        {
            "//;,1,\n2\n3".ShoulEqual(6);
        }

        [Fact]
        public void GivenNegativeThrowException()
        {
            Assert.Throws(typeof(ArgumentException), () => "-1".ShoulEqual(-1));
        }

        [Fact]
        public void GivenNegativeThrowExceptionWithMessages()
        {
            var ex = Assert.Throws(typeof(ArgumentException), () => "-1,-2".ShoulEqual(-1));
            Assert.Equal("Negatives not allowed: -1, -2", ex.Message);
        }

    }

    public static class Helpers
    {
        public static void ShoulEqual(this string input, int expected)
        {
            var cal = new StringCalculator();
            Assert.Equal(expected, cal.Add(input));
        }
    }

}
