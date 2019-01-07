using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Console.WriteLine("Please input a basic arithmetic function (+,-,*,/)");
            string userInput = Console.ReadLine();
            string[] parsedInput = userInput.Split(" ");

            //there should be an odd number indices; each even index should contain an string that can be converted to an int, each odd should be a command
            //Console.WriteLine(parsedInput.Length);
            if ((parsedInput.Length % 2) == 1)
            {
                //Basic syntax seems valid
                int first = 0;
                bool validFirst = Int32.TryParse(parsedInput[0], out first);
                while (!validFirst)
                {
                    parsedInput[0] = parsedInput[0].Substring(1);
                    validFirst = Int32.TryParse(parsedInput[0], out first);
                }
                int second = 0;
                bool validSecond = Int32.TryParse(parsedInput[2], out second);
                while (!validSecond)
                {
                    parsedInput[2] = parsedInput[2].Substring(1);
                    validSecond = Int32.TryParse(parsedInput[2], out second);
                }
                Console.WriteLine("Calculated answer: " + calc(first, parsedInput[1], second));
                Console.ReadLine();
            }
            else
            {
                //Syntax can't be valid
                Console.WriteLine("Invalid syntax detected - are you sure your input is in the form of (number) (operator) (number)? Aborting.");
                Console.ReadLine();
            }
        }

        static int calc(int a, string op, int b)
        {
            switch (op)
            {
                case "+":
                    return Add(a, b);
                case "-":
                    return Subtract(a, b);
                case "*":
                    return Multiply(a, b);
                case "/":
                    return Divide(a, b);
                default:
                    Console.WriteLine("Invalid syntax detected - are you sure your operator is one of +,-,*,/ ?");
                    Console.WriteLine("Attemped to calculate " + a + op + b);
                    return -1;
            }
        }
        //basic four-function functionality for the calculator
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Subtract(int a, int b)
        {
            return Add(a, -b);
        }
        static int Multiply(int a, int b)
        {
            return a * b;
        }
        static int Divide(int a, int b)
        {
            return a / b;
        }
    }
}
