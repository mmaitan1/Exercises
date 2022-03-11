using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using RTSLabsExercise;

class Program
{
    static void Main(string[] args)
    {
        ExampleClass example = new ExampleClass();

        Console.WriteLine("Select method to test. (1: aboveBelow, 2: stringRotation)");
        string methodTarget = Console.ReadLine();
        int methodInt = 0;

        try
        {
            methodInt = int.Parse(methodTarget);

            if (methodInt == 1)
            {
                string integerListAndOperand = "";

                Console.WriteLine("Enter a comma seperated list of integers, a ':' and a comparison operand. (eg. 1, 5, 2, 1, 10: 6)");
                integerListAndOperand = Console.ReadLine();
                
                if (!string.IsNullOrEmpty(integerListAndOperand) && integerListAndOperand.Contains(":"))
                {
                    string[] intListStrings = integerListAndOperand.Split(":", StringSplitOptions.RemoveEmptyEntries);
                    List<int> integerList = new List<int>();
                    int operand = 0;

                    Regex intListAndOperandRegex = new Regex(@"([0-9]+[,\s0-9]*)+(:[\s0-9]+)");
                    Regex intListRegex = new Regex(@"[0-9]+(,[\s0-9])*");

                    if (intListStrings.Length > 1 && intListAndOperandRegex.Match(integerListAndOperand).Success)
                    {
                        //Retrieve integer list
                        if (intListRegex.Match(intListStrings[0]).Success)
                        {
                            foreach (string number in intListStrings[0].Split(","))
                            {
                                try
                                {
                                    integerList.Add(int.Parse(number.Trim()));
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Failed to retrieve numbers for the integer list due to an invalid value");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("The integer list is in an invalid format");
                        }


                        //Retrieve the comparison operand
                        try
                        {
                            operand = int.Parse(intListStrings[1].Trim());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("The comparison operand entered was not a valid number");
                            return;
                        }


                        Dictionary<string, int> resultsDict = example.aboveBelow(integerList, operand);
                        Console.WriteLine("above: {0}, below: {1}", resultsDict["above"], resultsDict["below"])
;
                    }
                    else
                    {
                        Console.WriteLine("The entered integer list and operand were invalid");
                    }
                }
                else
                {
                    Console.WriteLine("No : was found so the integer list and operand entered were not valid");
                }

            }
            else if (methodInt == 2)
            {
                Regex stringRotateRegex = new Regex(@"[\w]+(,[\s0-9]+)+");
                string stringAndRotationInput = "";

                Console.WriteLine("Enter a string to rotate and the number of characters to rotate in the following format: {some string}, {number of rotations}");
                stringAndRotationInput = Console.ReadLine();

                if (stringRotateRegex.Match(stringAndRotationInput).Success)
                {
                    string[] inputStrings = stringAndRotationInput.Split(",");
                    int numberOfRotations = 0;

                    if (inputStrings.Length > 1)
                    {
                        try
                        {
                            numberOfRotations = int.Parse(inputStrings[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("The number of rotations was not a number.");
                            return;
                        }

                        if (inputStrings[0].Length > 0 && numberOfRotations > -1)
                        {
                            string resultString = example.stringRotation(inputStrings[0], numberOfRotations);
                            Console.WriteLine("rotated string: {0}", resultString);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The string to rotate and number of characters entered was invalid");
                    return;
                }
            }
            else
            {
                Console.WriteLine("An invalid method number was entered.");
                return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Invalid method was entered. The method selector must be numeric");
            return;
        }
    }
}