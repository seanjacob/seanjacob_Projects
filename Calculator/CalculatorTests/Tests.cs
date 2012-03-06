using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calculator;
using Xunit;

namespace CalculatorTests
{
    public class Tests
    {
        [Fact]
        public void GivenEmptyStringReturnZero()
        {            
            "".ShouldEqual(0);
        }

        [Fact]
        public void GivenNumberReturnsNumber()
        {
            "2".ShouldEqual(2);
        }

        [Fact]
        public void GivenNumberReturnsAnotherNumber()
        {
            "2".ShouldEqual(2);
        }

        [Fact]
        public void GivenTwoNumbersReturnsThereSum()
        {
            "3,2".ShouldEqual(5);
        }

        [Fact]
        public void GivenMultipleReturnsThereSum()
        {
            "3,2,1".ShouldEqual(6);
        }

        [Fact]
        public void GivenNewLineDelimiterReturnsThereSum()
        {
            "3\n2,1".ShouldEqual(6);
        }

        [Fact]
        public void GivenTwoDelimiterThrows()
        {
            Assert.Throws(typeof(ArgumentException), () => "1,,2".ShouldEqual(-1));
        }

        [Fact]
        public void GivenCustomDelimiterReturnsThereSum()
        {
            "//;\n3;2,1".ShouldEqual(6);
        }

        [Fact]
        public void GivenNegativeValuesThrows()
        {
            var ex = Assert.Throws(typeof(ArgumentException), () => "-1,2".ShouldEqual(-1));
            Assert.Contains("Negatives not allowed", ex.Message );
        }

        [Fact]
        public void GivenMultipleNegativeValuesThrowsDisplayNegativeNumbers()
        {
            var ex = Assert.Throws(typeof(ArgumentException), () => "-1,-2".ShouldEqual(-1));
            Assert.Contains("-1, -2", ex.Message);
        }
    }

    public static class Helpers
    {
        public static void ShouldEqual(this string input, int expected)
        {
            var cal = new StringCalculator();
            Assert.Equal(expected, cal.Add(input));
        }
    }

}
