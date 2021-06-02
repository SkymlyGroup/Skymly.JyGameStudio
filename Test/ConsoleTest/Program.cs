using System;
using System.IO;
using Tools;
using System.Dynamic;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace ConsoleTest
{

    class Program
    {
      
        static void Main(string[] args)
        {
            var name = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location);
            Console.WriteLine(name);
        }

    }
}
