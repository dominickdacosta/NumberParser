using NumberParser.Services;

namespace NumberParser
{
    public class NumberParserFactory
    {
        public static INumberParserService GetParserService(string serviceType)
        {
            INumberParserService numberParserService = null;

            if (serviceType == "XML")
            {
                numberParserService = new NumberParserXMLService();
            }
            else if (serviceType == "TXT")
            {
                numberParserService = new NumberParserTextService();
            }
            else if (serviceType == "JSON")
            {
                numberParserService = new NumberParserJSONService();
            }

            return numberParserService;
        }
    }
}
