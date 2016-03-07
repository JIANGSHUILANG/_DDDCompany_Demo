using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace 爬虫_01
{
    class Class1
    {
        static void Main()
        {
            //在广度优先的时候，我们需要注意两个问题：

            //①：有的时候网页是相对地址，我们需要转化为绝对地址。

            //②：剔除外链
            Crawler cl = new Crawler("http://www.cnblogs.com");

            cl.DownLoad();
            foreach (var item in Crawler.visited)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
    public class Crawler
    {
        public static Uri baseUri;
        public static string baseHost = string.Empty;

        //工作队列
        public static Queue<string> todo = new Queue<string>();

        //已访问的队列
        public static HashSet<string> visited = new HashSet<string>();

        public Crawler(string url)
        {
            baseUri = new Uri(url);
            //基域
            baseHost = baseUri.Host.Substring(baseUri.Host.IndexOf('.'));

            //抓取首地址入队
            todo.Enqueue(url);
        }

        public void DownLoad()
        {
            while (todo.Count > 0)
            {
                var currenturl = todo.Dequeue();

                if (!currenturl.Contains(baseHost))
                    continue;
                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(currenturl);
                    var response = (HttpWebResponse)request.GetResponse();
                    var sr = new StreamReader(response.GetResponseStream());
                    string tempstr = sr.ReadToEnd();
                    //当前url标记为已访问过
                    visited.Add(currenturl);
                    Console.WriteLine(currenturl);
                    RefineUrl(tempstr);
                }
                catch (Exception ex)
                {
                    visited.Add("错误链接：" + currenturl);
                    Console.WriteLine("错误链接：" + currenturl);
                    continue;
                }
                //提取url，将未访问的放入todo表中

            }
        }

        public void RefineUrl(string html)
        {
            var reg = new Regex(@"(?is)<a[^>]*?href=(['""]?)(?<url>[^'""\s>]+)\1[^>]*>(?<text>(?:(?!</?a\b).)*)</a>");
            MatchCollection mc = reg.Matches(html);

            foreach (Match item in mc)
            {
                string url = item.Groups["url"].Value;

                if (url == "#")
                    continue;

                ////相对路径转换为绝对路径
                Uri uri = new Uri(baseUri, url);

                ////剔除外网链接(获取顶级域名)
                if (!uri.Host.EndsWith(baseHost))
                    continue;

                if (!visited.Contains(url.ToString()))
                {
                    todo.Enqueue(url.ToString());
                }
            }
        }
    }
}
