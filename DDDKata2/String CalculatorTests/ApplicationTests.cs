using DDDKata2;
using DDDKata2.Interfaces;
using Moq;
using Xunit;
namespace String_CalculatorTests
{
    public class ApplicationTests
    {
        public Mock<IConsole> ConsoleMock { get; set; }
        public StringCalculator Calculator { get; set; }
        public Application Application { get; set; }
        
        public ApplicationTests()
        {
            ConsoleMock = new Mock<IConsole>();
            Calculator = new StringCalculator(ConsoleMock.Object);
            Application = new Application(Calculator, ConsoleMock.Object);
        }
        
        [Fact]
        public void GivenEmptyStringOutPutsZero()
        {
            RunMain("0");
            VerifyOutput("0");
        }

        [Fact]
        public void GivenASingleNumberShouldOutputNumber()
        {
            RunMain("1");
            VerifyOutput("1");
        }

        [Fact]
        public void AppAlwaysPromptsForAnotherInput()
        {
            RunMain("1");
            ConsoleMock.Verify(x => x.WriteLine("Another input please"));
        }

        [Fact]
        public void AppAlwaysChecksForAnotherInput()
        {
            RunMain("1");
            ConsoleMock.Verify(x => x.Readline());
        }

        [Fact]
        public void GivenSecondCalculationOutputResults()
        {
            ConsoleMock.SetupSequence(x => x.Readline()).Returns("1,2");
            RunMain("1");            
            VerifyOutput("3");
        }

        [Fact]
        public void GivenEmptyInputPrgramExits()
        {
            ConsoleMock.SetupSequence(x => x.Readline()).Returns("");
            RunMain("1");
            ConsoleMock.Verify(x => x.Readline(),Times.Exactly(1));
        }

        [Fact]
        public void GivenNCalculationsOutsputResults()
        {
            ConsoleMock.SetupSequence(x => x.Readline()).Returns("1,2").Returns("3,4").Returns("");
            RunMain("1");
            VerifyOutput("7");
        }

        private void RunMain(string input)
        {
            Application.Main(new[] {input});
        }

        private void VerifyOutput(string expected)
        {
            ConsoleMock.Verify(x => x.WriteLine(StringCalculator.OutputPrefix + expected));
        }
    }
}
