using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Tools
{
    public static class HttpUtils
    {
        public static string CommonHttpRequest(string url, string type = "Post", string data = null, int timeOut = 0, string contentType = "application/json ;charset = UTF-8", params (string Key, string Value)[] headers)
        {
            HttpWebRequest myRequest = null;
            try
            {
                //构造http请求的对象
                myRequest = (HttpWebRequest)WebRequest.Create(url);
                //设置
                myRequest.Method = type;
                myRequest.ContentType = contentType;
                myRequest.Timeout = timeOut;
                if (headers != null)
                {
                    foreach ((string Key, string Value) in headers)
                    {
                        myRequest.Headers.Add(Key, Value);
                    }
                }
                if (data.Trim() != "")
                {

                    using StreamWriter writer = new StreamWriter(myRequest.GetRequestStream(), Encoding.UTF8);
                    writer.Write(data);
                    writer.Flush();
                }
                // 获得接口返回值
                using var myResponse = (HttpWebResponse)myRequest.GetResponse();
                using var reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string result = reader.ReadToEnd();
                reader.Close();
                myResponse.Close();
                myRequest.Abort();
                return result;
            }
            catch (Exception)
            {
                if (myRequest != null)
                    myRequest.Abort();
                return "";
            }
        }

        public static string CommonHttpRequest(string url, string type = "Post", IEnumerable<KeyValuePair<string, string>> headers = null, string data = null, int timeOut = 0, string contentType = "application/json ;charset = UTF-8")
        {
            HttpWebRequest myRequest = null;
            try
            {
                //构造http请求的对象
                myRequest = (HttpWebRequest)WebRequest.Create(url);
                //设置
                myRequest.Method = type;
                myRequest.ContentType = contentType;
                myRequest.Timeout = timeOut;
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        myRequest.Headers.Add(item.Key, item.Value);
                    }
                }
                if (data.Trim() != "")
                {

                    using StreamWriter writer = new StreamWriter(myRequest.GetRequestStream(), Encoding.UTF8);
                    writer.Write(data);
                    writer.Flush();
                }
                // 获得接口返回值
                using var myResponse = (HttpWebResponse)myRequest.GetResponse();
                using var reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string result = reader.ReadToEnd();
                reader.Close();
                myResponse.Close();
                myRequest.Abort();
                return result;
            }
            catch (Exception)
            {
                if (myRequest != null)
                    myRequest.Abort();
                return "";
            }
        }
    }
}
