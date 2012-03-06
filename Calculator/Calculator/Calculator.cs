using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            string dels = ",\n";

            if(input.StartsWith("//"))
            {
                dels += input[2];
                input = input.Substring(4);
            }

            var items = input.Split(dels.ToCharArray());
            if(items.Any(item => string.IsNullOrEmpty(item)))
                throw new ArgumentException();
            
            var ints = items.Select(item => int.Parse(item));
            var negatives = ints.Where(x => x < 0);

            if (negatives.Count() > 0)
                throw new ArgumentException(string.Format("Negatives not allowed {0}", string.Join(", ", negatives)));

            return ints.Sum();
        }
    }
}
