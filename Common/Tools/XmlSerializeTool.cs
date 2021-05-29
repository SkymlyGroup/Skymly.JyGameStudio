using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Tools
{
    public static class XmlSerializeTool
    {
        /// <summary>     
        /// XML序列化某一类型到指定的文件   
        /// /// </summary>   
        /// /// <param name="filePath"></param>   
        /// /// <param name="obj"></param>  
        /// /// <param name="type"></param>   
        public static void SerializeToFile<T>(string filePath, T obj)
        {
            try
            {
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "");
                using StreamWriter writer = new StreamWriter(filePath);
                XmlSerializer xs = new XmlSerializer(type: typeof(T), root: new XmlRootAttribute("root"));
                xs.Serialize(writer, obj, namespaces);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

       
        public static string SerializeToString<T>(T obj)
        {
            //为了去掉开头的声明和名称空间 所以多了一些额外操作
            using MemoryStream stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(typeof(T));           
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "    ";
            settings.NewLineChars = "\r\n";
            settings.Encoding = Encoding.UTF8;
            settings.OmitXmlDeclaration = true;  // 不生成声明头
            XmlWriter writer = XmlWriter.Create(stream, settings);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);//空的名称空间
            xml.Serialize(writer, obj, namespaces);
            stream.Position = 0;
            using StreamReader sr = new StreamReader(stream);
            string str = sr.ReadToEnd();
            writer.Close();
            writer.Dispose();
            return str;
        }


        public static T DeserializeFromString<T>(string XmlString)
        {
            if (string.IsNullOrEmpty(XmlString))
                throw new ArgumentNullException("s");

            using var ms = new MemoryStream(Encoding.UTF8.GetBytes(XmlString));
            var xr = XmlReader.Create(ms);
            var xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute("root"));
            return (T)xmlSerializer.Deserialize(xr);
        }


        /// <summary>
        /// 我印象中这两个DeserializeFromFile有一个在xamarin中有问题，有待验证
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T DeserializeFromFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File {filePath} not Exists");
            }
            using StreamReader reader = new StreamReader(filePath);
            XmlSerializer xs = new XmlSerializer(typeof(T));
            T ret = (T)xs.Deserialize(reader);
            return ret;
        }

        public static T DeserializeFromFile2<T>(string path)
        {
            if (File.Exists(path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                var xml = doc.InnerXml;
                using MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
                using var reader = new StreamReader(ms);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            }
            throw new FileNotFoundException($"File {path} not Exists");
        }

    }
}
