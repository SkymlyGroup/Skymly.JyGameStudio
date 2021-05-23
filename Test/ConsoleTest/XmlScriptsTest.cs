using Skymly.JyGameTools.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

using Tools;

namespace ConsoleTest
{
    public static class XmlScriptsTest
    {
        static XmlScriptsTest()
        {
            //Directory.CreateDirectory("ScriptsResult");
        }


        public static void Aoyi_Test1()
        {
            var xml = File.ReadAllText("Scripts/aoyis.xml");
            var aoyiRoot = XmlSerializeTool.DeserializeFromString<AoyiRoot>(xml);
            Console.WriteLine(aoyiRoot.Aoyis.Count);
            var xml2 = XmlSerializeTool.SerializeToString(aoyiRoot);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml2);
            Console.WriteLine(xml2);
            File.WriteAllText("Scripts/aoyisResult.xml", xml2);

            var count1 = xml.Where(v => !string.IsNullOrWhiteSpace(v.ToString())).Count();
            var count2 = xml2.Where(v => !string.IsNullOrWhiteSpace(v.ToString())).Count();
            Console.WriteLine($"count1={count1}  count2={count2}");
            Debug.Assert(count1 == count2);

        }
        public static void Aoyi_Test2()
        {
            var aoyiRoot = XmlSerializeTool.DeserializeFromFile2<AoyiRoot>("Scripts/aoyis.xml");
            Console.WriteLine(aoyiRoot.Aoyis.Count);
        }

        public static void Aoyi_Test3()
        {
            var aoyiRoot = XmlSerializeTool.DeserializeFromFile<AoyiRoot>("Scripts/aoyis.xml");
            Console.WriteLine(aoyiRoot.Aoyis.Count);
        }

        public static void Battle_Test1()
        {
            var xml = File.ReadAllText("Scripts/battles.xml");
            var root = XmlSerializeTool.DeserializeFromString<BattleRoot>(xml);
            Console.WriteLine(root.Battles.Count);
            var xml2 = XmlSerializeTool.SerializeToString(root);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml2);
            Console.WriteLine(xml2);


          
           

            File.WriteAllText("Scripts/battlesResult.xml", xml2);
            var count1 = xml.Where(v => !string.IsNullOrWhiteSpace(v.ToString())).Count();
            var count2 = xml2.Where(v => !string.IsNullOrWhiteSpace(v.ToString())).Count();
            Console.WriteLine($"count1={count1}  count2={count2}");
            Debug.Assert(count1 == count2);
        }

    }
}
