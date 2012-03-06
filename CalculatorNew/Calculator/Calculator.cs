using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorNew
{
    public class StringCalculator
    {
        
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            var dels = ",\n";
            
            if(input.StartsWith("//"))
            {
                dels += input[2];
                input = input.Substring(4);
            }                        
            
            var items = input.Split(dels.ToCharArray()).Where(s => !string.IsNullOrEmpty(s));
            var ints = items.ToList().ConvertAll(Convert.ToInt32);
            
            var negatives = ints.Where(i => i < 0).ToList();

            if(negatives.Count > 0)
                throw new ArgumentException(string.Format("Negatives not allowed: {0}",string.Join(", ",negatives)));
                        
            return ints.Sum();
        }

    }
}
