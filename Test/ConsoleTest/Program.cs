using System;
using System.IO;

using Tools;
using Skymly.JyGameTools.Models;
using System.Xml;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            LuaTest.UseLuaTable();
            Console.WriteLine("Hello World!");
        }

        static void Aoyi_Test1()
        {
            var xml = File.ReadAllText("Scripts/aoyis.xml");
            var aoyiRoot = XmlSerializeTool.DeserializeFromString<AoyiRoot>(xml);
            Console.WriteLine(aoyiRoot.Aoyis.Count);
            var xml2 = XmlSerializeTool.SerializeToString(aoyiRoot);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml2);
            Console.WriteLine(xml2);
            Directory.CreateDirectory("ScriptsResult");
            File.WriteAllText("ScriptsResult/aoyis.xml", xml2);
        }
        static void Aoyi_Test2()
        {
            var aoyiRoot = XmlSerializeTool.DeserializeFromFile2<AoyiRoot>("Scripts/aoyis.xml");
            Console.WriteLine(aoyiRoot.Aoyis.Count);
        }

        static void Aoyi_Test3()
        {
            var aoyiRoot = XmlSerializeTool.DeserializeFromFile<AoyiRoot>("Scripts/aoyis.xml");
            Console.WriteLine(aoyiRoot.Aoyis.Count);
        }
    }
}
