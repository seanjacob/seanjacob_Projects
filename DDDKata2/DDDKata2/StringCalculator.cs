using System;
using System.Linq;
using DDDKata2.Interfaces;

namespace DDDKata2
{
    public class StringCalculator
    {

        public const string OutputPrefix = "The result is ";
        public IConsole Console { get; set; }

        public StringCalculator(IConsole console)
        {
            Console = console;
        }

        public int Add(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                OutputResult(0);
                return 0;
            }

            var delimters = ",\n";
            if (input.Contains("//"))
            {
                delimters += input[2];
                input = input.Substring(3, input.Length - 3);
            }

            var items = input.Split(delimters.ToCharArray());
            if (items.Any(x => string.IsNullOrEmpty(x)))
                throw new ArgumentException();

            var integers = items.Select(x => int.Parse(x));
            var negatives = integers.Where(x => x < 0);
            if (negatives.Any())
            {
                var message = "Negatives not allowed {0}";
                throw new ArgumentException(string.Format(message, string.Join(",", negatives.Select(x => x.ToString()).ToArray())));
            }
            var result = integers.Sum();
            OutputResult(result);
            return result;
        }

        private void OutputResult(int result)
        {
            if (Console != null) Console.WriteLine(OutputPrefix + result.ToString());
        }
    }
}
