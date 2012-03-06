using DDDKata2;
using DDDKata2.Interfaces;
using Moq;
using Xunit;
namespace String_CalculatorTests
{
    public class ConoleTests
    {
        [Fact]
        public void GivenAnEmptyStringOutputsZeroToTheScreen()
        {
            var consoleMock = new Mock<IConsole>();
            var calc = new StringCalculator(consoleMock.Object);
            calc.Add("");
            consoleMock.Verify(x => x.WriteLine(StringCalculator.OutputPrefix + "0"));
        }

        [Fact]
        public void GivenASingleNumberShouldOutputNumber()
        {
            var consoleMock = new Mock<IConsole>();
            var calc = new StringCalculator(consoleMock.Object);
            calc.Add("1");
            consoleMock.Verify(x => x.WriteLine(StringCalculator.OutputPrefix + "1"));
        }
    }
}
