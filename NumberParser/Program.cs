using System;
using System.Linq;
using NumberParser.Services;

namespace NumberParser
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args.Length == 2)
            {             
                string orginalInputString = args[0];
                string outputFormat = args[1].ToUpper();

                var outputFormatOptions = new[] { "XML", "JSON", "TXT" };

                if (!outputFormatOptions.Contains(outputFormat))
                {
                    Console.WriteLine("Invalid Output Format! The options you have are 'XML', 'JSON', 'TXT'. Exiting the application");
                    return;
                }

                int[] intArray = CreateIntegerArray(orginalInputString);

                // Display Results
                Console.WriteLine($"{Environment.NewLine}Sorted Output:");
                foreach (int arrayElement in intArray)
                    Console.WriteLine(arrayElement.ToString());

                Console.WriteLine("Do you want to print the output to a file (Y/N):");
                string userInput = Console.ReadLine();
                if (string.Equals(userInput, "Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    INumberParserService parserService = NumberParserFactory.GetParserService(outputFormat.ToUpper());

                    if (parserService != null)
                        parserService.CreateOutput(orginalInputString, intArray);
                }
                else if (string.Equals(userInput, "N", StringComparison.InvariantCultureIgnoreCase))
                    return;
                else
                {
                    Console.WriteLine("Invalid Input! Exiting the application");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Incorrect paramters were supplied to the program");
            }
        }

        static int[] CreateIntegerArray(string inputString)
        {
            var stringArray = inputString.Split(",");
            int[] intArray = new int[stringArray.Length];

            for (int index = 0; index < stringArray.Length; index++)
                int.TryParse(stringArray[index], out intArray[index]);

            //Array.Sort(intArray);
            //Array.Reverse(intArray);

            int temp = 0;

            for (int i = 0; i <= intArray.Length - 1; i++)
            {
                for (int j = i + 1; j < intArray.Length; j++)
                {
                    if (intArray[i] < intArray[j])
                    {
                        temp = intArray[i];
                        intArray[i] = intArray[j];
                        intArray[j] = temp;
                    }
                }
            }

            return intArray;
        }
    }
}