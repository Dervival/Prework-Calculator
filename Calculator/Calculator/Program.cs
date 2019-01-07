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
                //debug for seeing parsed input array before any computation is done
                    //Console.Write("Parsed input: [");
                    //for(int i = 0; i < parsedInput.Length-1; i++)
                    //{
                    //    Console.Write(parsedInput[i] + ",");
                    //}
                    //Console.WriteLine(parsedInput[parsedInput.Length - 1] + "]");
                    //Console.ReadLine();
                //multDivArray should be the array after both multiplication and division are done
                string[] multDivArray = multDivPassThrough(parsedInput);
                //finalResult should be an array of length 1, whose contents are the final calculated value
                string[] finalResult = addSubPassThrough(multDivArray);
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
                        for (int j = 0; j < i - 1; j++)
                        {
                            newArray[j] = array[j];
                        }
                        //merged center "subarray" (only the single value)
                        Int32.TryParse(array[i - 1], out int firstVal);
                        Int32.TryParse(array[i + 1], out int secondVal);
                        int newVal = calc(firstVal, array[i], secondVal);
                        newArray[i - 1] = newVal.ToString();
                        //right subarray
                        for (int j = i; j < array.Length - 2; j++)
                        {
                            newArray[j] = array[j + 2];
                        }
                        //reset the computation to the start of the array again
                        array = newArray;
                        i = 0;
                    }
                    if (array[i] == "/")
                    {
                        //division
                        string[] newArray = new string[array.Length - 2];
                        //left subarray 
                        for (int j = 0; j < i - 1; j++)
                        {
                            newArray[j] = array[j];
                        }
                        //merged center "subarray" (only the single value)
                        Int32.TryParse(array[i - 1], out int firstVal);
                        Int32.TryParse(array[i + 1], out int secondVal);
                        int newVal = calc(firstVal, array[i], secondVal);
                        newArray[i - 1] = newVal.ToString();
                        //right subarray
                        for (int j = i; j < array.Length - 2; j++)
                        {
                            newArray[j] = array[j + 2];
                        }
                        //reset the computation to the start of the array again
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
                        for (int j = 0; j < i - 1; j++)
                        {
                            newArray[j] = array[j];
                        }
                        //merged center "subarray" (only the single value)
                        Int32.TryParse(array[i - 1], out int firstVal);
                        Int32.TryParse(array[i + 1], out int secondVal);
                        int newVal = calc(firstVal, array[i], secondVal);
                        newArray[i - 1] = newVal.ToString();
                        //right subarray
                        for (int j = i; j < array.Length - 2; j++)
                        {
                            newArray[j] = array[j + 2];
                        }
                        //reset the computation to the start of the array again
                        array = newArray;
                        i = 0;
                    }
                    if (array[i] == "-")
                    {
                        //subtraction
                        string[] newArray = new string[array.Length - 2];
                        //left subarray 
                        for (int j = 0; j < i - 1; j++)
                        {
                            newArray[j] = array[j];
                        }
                        //merged center "subarray" (only the single value)
                        Int32.TryParse(array[i - 1], out int firstVal);
                        Int32.TryParse(array[i + 1], out int secondVal);
                        int newVal = calc(firstVal, array[i], secondVal);
                        newArray[i - 1] = newVal.ToString();
                        //right subarray
                        for (int j = i; j < array.Length - 2; j++)
                        {
                            newArray[j] = array[j + 2];
                        }
                        //reset the computation to the start of the array again
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
