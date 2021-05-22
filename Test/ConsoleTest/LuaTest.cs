using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

using NLua;
namespace ConsoleTest
{
    public static class LuaTest
    {
        public static void DoStringTest()
        {
            using Lua lua = new Lua();
            lua.LoadCLRPackage();
            string chunk = @"
local a = 5;
local b = 15; 
local function foo(m,n) 
    return m * n 
end  
local c = foo(a,b) ; 
print(c)";
            lua.DoString(chunk);
        }

        /// <summary>
        /// 返回值
        /// </summary>
        public static void ReturnResult()
        {
            using Lua lua = new Lua();
            lua.LoadCLRPackage();
            string chunk = @"
local a = 5;
local b = 15; 
local function foo(m,n)
    return m * n , m+n; 
end
return foo(a,b)
";
            object[] result = lua.DoString(chunk);
            Debug.Assert(result.Length == 2);//根据预期会返回2个值
            Console.WriteLine(result.Length);
            Console.WriteLine(result[0].GetType().FullName);
            Console.WriteLine(result[0]);
            Console.WriteLine(result[1].GetType().FullName);
            Console.WriteLine(result[1]);

        }
        /// <summary>
        /// 把.net变量注册到LuaState
        /// </summary>
        public static void RegisterValues()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 500;
            timer.Elapsed += (s, e) => Console.WriteLine(DateTime.Now.ToString("s"));
            Random r = new Random((int)DateTime.Now.Ticks);
            using Lua lua = new Lua();
            lua.LoadCLRPackage();
            lua["timer"] = timer;
            lua["random"] = r;
            var thuck = @"
import('System.Threading')
while true do
    local v = random:Next(100)
    print(v)
    if  v > 80 then
        timer.Enabled = not timer.Enabled;
    end
    Thread.Sleep(1000);
end       
";
            lua.DoString(thuck);

        }


        /// <summary>
        /// 在Lua中使用CLR类型与方法
        /// </summary>
        public static void UseClrType()
        {
            using Lua lua = new Lua();
            lua.LoadCLRPackage();
            string chunk = @"
import('System')
local random = Random(DateTime.Now.Ticks)
for i = 1,20 do
    Console.WriteLine(String.Format('{0}\t{1}',i,random:Next(0,1000)));
end
";
            lua.DoString(chunk);
        }

        /// <summary>
        /// 返回LuaTable，并且用C#解析
        /// </summary>
        public static void UseLuaTable()
        {
            using Lua lua = new Lua();
            lua.LoadCLRPackage();
            Random r = new Random((int)DateTime.Now.Ticks);
            lua["random"] = r;
            string chunk = @"
import('System.Runtime.dll','System')
local count = random:Next(10,20);            
local t = {}
for i = 1,count do
    local k = Guid.NewGuid():ToString();
    local v = random:NextDouble();
    t[k] = v;
end
for k,v in pairs(t) do
 print(k..'\t'..v)
end
return t;
";
            var result = lua.DoString(chunk);
            Console.WriteLine(string.Concat(Enumerable.Repeat('*',100)));
            Console.WriteLine(string.Concat(Enumerable.Repeat("#A*", 40)));
            Dictionary<string, double> pairs = lua.GetTableDict(result[0] as LuaTable).ToDictionary(v => v.Key.ToString(), v => (double)(v.Value));
            //LuaTable table = result[0] as LuaTable;
            //var keys = table.Keys.OfType<string>().ToList();
            //var values = table.Values.OfType<double>().ToList();
            //Dictionary<string, double> pairs = keys.ToDictionary(v => v, v => values[keys.IndexOf(v)]);
            foreach (var item in pairs)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
        }
    }
}
