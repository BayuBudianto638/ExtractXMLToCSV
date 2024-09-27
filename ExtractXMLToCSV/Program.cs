using System;
using System.IO;
using System.Xml;

class Program
{
    static void Main()
    {
        string xmlFilePath = "your_xml_file.xml";
        string csvFilePath = "output.csv";

        try
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            using (StreamWriter writer = new StreamWriter(csvFilePath))
            {
                writer.WriteLine("lob,ruleId,defaultName,modelDesc,ruleType,isForDisplay,mainEntityType,maxScore,scoreCalcMethod,isRecurrenceByMonth,...");

                foreach (XmlNode node in xmlDoc.DocumentElement.SelectNodes("//rule"))
                {
                    string lob = node.SelectSingleNode("lob").InnerText;
                    string ruleId = node.SelectSingleNode("id").InnerText;

                    writer.WriteLine($"{lob},{ruleId}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}