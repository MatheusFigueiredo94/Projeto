using Newtonsoft.Json;
using ProcessaXml.Entidade;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProcessaXml
{
    public class Principal
    {
        public static void OnStart()
        {
            buscaXmlPasta();

        }

        public static void buscaXmlPasta()
        {
            try
            {

                string[] dirs = Directory.GetFiles(@"C:\Projeto\", "*.xml");

                foreach (string dir in dirs)
                {

                    processaXml(dir);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Falha no método buscaTrabalhosPasta(): {0}", e.ToString());
            }

        }

        public static void processaXml(string dir)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(dir);

            XmlNodeList nodeListXml = doc.DocumentElement.SelectNodes(".//row");

            DateTime day;
            decimal clicks, impressions, views, avgCPM, avgCPC, ctr, conversions, cost;
            Int64 campaignID;
            string campaign;
            String xmlFinal = "";

            foreach (XmlNode node in nodeListXml)
            {
                day = Convert.ToDateTime(node.Attributes["day"]?.InnerText);
                clicks = Convert.ToDecimal(node.Attributes["clicks"]?.InnerText);
                impressions = Convert.ToDecimal(node.Attributes["impressions"]?.InnerText);
                views = Convert.ToDecimal(node.Attributes["views"]?.InnerText);
                avgCPM = Convert.ToDecimal(node.Attributes["avgCPM"]?.InnerText);
                avgCPC = Convert.ToDecimal(node.Attributes["avgCPC"]?.InnerText);
                ctr = Convert.ToDecimal(node.Attributes["ctr"]?.InnerText.Remove(node.Attributes["ctr"].InnerText.Length - 1));
                conversions = Convert.ToDecimal(node.Attributes["conversions"]?.InnerText);
                cost = Convert.ToDecimal(node.Attributes["cost"]?.InnerText);
                campaignID = Convert.ToInt64(node.Attributes["campaignID"]?.InnerText);
                campaign = node.Attributes["campaign"]?.InnerText.ToString();

                Xml xml = new Xml(day, clicks, impressions, views, avgCPM, avgCPC, ctr, conversions, cost, campaignID, campaign);
                xmlFinal += JsonConvert.SerializeObject(xml);
            }


            Console.WriteLine(xmlFinal);

        }

    }
}
