using System;
using System.IO;
using System.Text;

namespace NumberParser.Services
{
    public class NumberParserTextService : INumberParserService
    {
        public void CreateOutput(string inputString, int[] sortedArray)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"InputString: {inputString}");
            sb.Append(Environment.NewLine);
            sb.Append($"Output: ");
            foreach (int arrayElement in sortedArray)
            {
                sb.Append(arrayElement.ToString());
                sb.Append(',');
            }
            sb.Length--;    // Remove last trailing character

            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Combine the application directory with the file name
            string filePath = Path.Combine(appDirectory, "output.text");

            // Write the text to the file
            File.WriteAllText(filePath, sb.ToString());

            Console.WriteLine($"Text saved to: {filePath}");
        }
    }
}
