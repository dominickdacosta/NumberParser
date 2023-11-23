using System;
using System.IO;
using System.Xml.Serialization;

namespace NumberParser.Services
{
    public class NumberParserXMLService : INumberParserService
    {
       
        public void CreateOutput(string inputString, int[] sortedArray)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(OutputObject));

            OutputObject outputObject = new OutputObject
            {
                InputString = inputString,
                Output = sortedArray
            };

            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(appDirectory, "output.xml");

            // Write the text to the file
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, outputObject);
            }

            Console.WriteLine($"Text saved to: {filePath}");
        }
    }

    [Serializable]
    public class OutputObject
    {
        public string InputString { get; set; }
        public int[] Output { get; set; }
    }
}
