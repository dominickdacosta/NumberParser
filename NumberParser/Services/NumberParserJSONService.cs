using System;
using System.IO;
using System.Text.Json;

namespace NumberParser.Services
{
    public class NumberParserJSONService : INumberParserService
    {
        public void CreateOutput(string inputString, int[] sortedArray)
        {
            OutputObject outputObject = new OutputObject
            {
                InputString = inputString,
                Output = sortedArray
            };
            string jsonString = JsonSerializer.Serialize(outputObject);
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Combine the application directory with the file name
            string filePath = Path.Combine(appDirectory, "output.json");

            // Write the text to the file
            File.WriteAllText(filePath, jsonString);

            Console.WriteLine($"Text saved to: {filePath}");
        }         
    }
  
}
