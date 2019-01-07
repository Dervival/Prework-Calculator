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
                for(int i = 0; i < parsedInput.Length; i++)
                {
                    ////due to splitting on " ", every value past the first will have an extra space
                    //if(i > 0 && i % 2 == 0)
                    //{
                    //    parsedInput[i] = parsedInput[i].Substring(1);
                    //}
                }
                Console.Write("Parsed input: [");
                for(int i = 0; i < parsedInput.Length-1; i++)
                {
                    Console.Write(parsedInput[i] + ",");
                }
                Console.WriteLine(parsedInput[parsedInput.Length - 1] + "]");
                Console.ReadLine();
                string[] multDivArray = multDivPassThrough(parsedInput);
                string[] finalResult = addSubPassThrough(multDivArray);
                //int first = 0;
                //bool validFirst = Int32.TryParse(parsedInput[0], out first);
                //while (!validFirst)
                //{
                //    parsedInput[0] = parsedInput[0].Substring(1);
                //    validFirst = Int32.TryParse(parsedInput[0], out first);
                //}
                //int second = 0;
                //bool validSecond = Int32.TryParse(parsedInput[2], out second);
                //while (!validSecond)
                //{
                //    parsedInput[2] = parsedInput[2].Substring(1);
                //    validSecond = Int32.TryParse(parsedInput[2], out second);
                //}
                Console.WriteLine("Calculated answer: " + finalResult[0]);
                Console.ReadLine();
            }
            else
            {
                //Syntax can't be valid
                Console.WriteLine("Invalid syntax detected - are you sure your input is in the form of (number) (operator) (number)? Aborting.");
                Console.ReadLine();
            }
        }

        static string[] multDivPassThrough(string[] array)
        {
            //given an array of integers in string and operators as strings, do multiplication and division from left to right
            for(int i = 0; i < array.Length; i++)
            {
                if(i % 2 == 1)
                {
                    //index is odd, should be operator
                    if(array[i] == "*")
                    {
                        //multiplication
                        string[] newArray = new string[array.Length - 2];
                        //left subarray 
                        for(int j = 0; j < i-2; j++)
                        {
                            newArray[j] = array[j];
                        }
                        //merged center "subarray" (only the single value)
                        newArray[i-1] = calc(Int32.Parse(array[i - 1]), array[i], Int32.Parse(array[i + 2])).ToString();
                        //right subarray
                        for (int j = i; j < array.Length-2; j++)
                        {
                            newArray[j] = array[j + 2];
                        }
                        array = newArray;
                        i = 0;
                    }
                    if (array[i] == "/")
                    {
                        //division
                        string[] newArray = new string[array.Length - 2];
                        //left subarray 
                        for (int j = 0; j < i - 2; j++)
                        {
                            newArray[j] = array[j];
                        }
                        //merged center "subarray" (only the single value)
                        newArray[i - 1] = calc(Int32.Parse(array[i - 1]), array[i], Int32.Parse(array[i + 2])).ToString();
                        //right subarray
                        for (int j = i; j < array.Length - 2; j++)
                        {
                            newArray[j] = array[j + 2];
                        }
                        array = newArray;
                        i = 0;
                    }
                }
            }
            return array;
        }
        static string[] addSubPassThrough(string[] array)
        {
            //given an array of integers in string and operators as strings, do multiplication and division from left to right
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 1)
                {
                    //index is odd, should be operator
                    if (array[i] == "+")
                    {
                        //addition
                        string[] newArray = new string[array.Length - 2];
                        //left subarray 
                        for (int j = 0; j < i - 2; j++)
                        {
                            newArray[j] = array[j];
                        }
                        //merged center "subarray" (only the single value)
                        Console.WriteLine("Attempting to do the following: " + array[i - 1] + array[i] + array[i + 1]);
                        Int32.TryParse(array[i - 1], out int firstVal);
                        Int32.TryParse(array[i + 1], out int secondVal);
                        int newVal = calc(firstVal, array[i], secondVal);
                        Console.WriteLine("Resulted in " + newVal);
                        newArray[i - 1] = newVal.ToString();
                        //right subarray
                        for (int j = i; j < array.Length - 2; j++)
                        {
                            newArray[j] = array[j + 2];
                        }
                        array = newArray;
                        Console.Write("array now: [");
                        for (int j = 0; j < array.Length - 1; j++)
                        {
                            Console.Write(array[j] + ",");
                        }
                        Console.WriteLine(array[array.Length - 1] + "]");
                        i = 0;
                    }
                    if (array[i] == "-")
                    {
                        //subtraction
                        string[] newArray = new string[array.Length - 2];
                        //left subarray 
                        for (int j = 0; j < i - 2; j++)
                        {
                            newArray[j] = array[j];
                        }
                        //merged center "subarray" (only the single value)
                        newArray[i - 1] = calc(Int32.Parse(array[i - 1]), array[i], Int32.Parse(array[i + 2])).ToString();
                        //right subarray
                        for (int j = i; j < array.Length - 2; j++)
                        {
                            newArray[j] = array[j + 2];
                        }
                        array = newArray;
                        i = 0;
                    }
                }
            }
            return array;
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
