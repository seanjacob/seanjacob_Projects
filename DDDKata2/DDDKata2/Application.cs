using DDDKata2.Interfaces;

namespace DDDKata2
{
    public class Application
    {
        public StringCalculator Calculator { get; set; }
        public IConsole Console { get; set; }

        public Application(StringCalculator calculator, IConsole console)
        {
            Calculator = calculator;
            Console = console;
        }

        public void Main(string[] args)
        {
            RunCalculatorAndRePrompt(args[0]);
            var nextInput = "";
            do
            {
                nextInput = Console.Readline();
                if (string.IsNullOrEmpty(nextInput) == false)
                    RunCalculatorAndRePrompt(nextInput);
                
            } while (string.IsNullOrEmpty(nextInput) == false);
        }

        private void RunCalculatorAndRePrompt(string input)
        {
            Calculator.Add(input);
            Console.WriteLine("Another input please");
        }
    }
}
