using System;

namespace StringCalculator
{
    public class Calculator
    {
        private const int LargeNumberThreshold = 1000;

        public static int Calculate(string argument)
        {
            if (argument.Length == 0)
                return 0;

            // single separator
            char newSeparator = ' ';
            if (argument.Length >= 3 && argument[0] == '/' && argument[1] == '/' && argument[2] != '[')
            {
                newSeparator = argument[2];
                argument = argument.Substring(3);
            }

            // multi char separator
            if (argument.Length >= 3 && argument[0] == '/' && argument[1] == '/' && argument[2] == '[')
            {
                int position = argument.IndexOf(']');

                string multiCharSeparator = argument.Substring(3, position - 3);

                argument = argument.Replace(multiCharSeparator, ",");

                argument = argument.Substring(5);
            }

            var numbers = argument.Split(',', '\n', newSeparator);
            int sum = 0;

            foreach (var number in numbers)
            {
                int.TryParse(number, out int num);

                if (num < 0)
                    throw new ArgumentException();

                if (num <= LargeNumberThreshold)
                    sum += num;
            }

            return sum;
        }
    }
}
