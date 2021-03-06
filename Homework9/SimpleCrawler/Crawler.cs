﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SimpleCrawler
{
    class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;

        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();

            string startUrl = "https://mbd.baidu.com/newspage/data/landingsuper?context=%7B%22nid%22%3A%22news_8952271450527329908%22%7D&n_type=0&p_from=1";
            if(args.Length >= 1)
            {
                startUrl = args[0];
            }

            myCrawler.urls.Add(startUrl, false);

            new Thread(myCrawler.Crawl).Start();
            
        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了.....");
            while (true)
            {
                string current = null;
                foreach(string url in urls.Keys)
                {
                    if ((bool)urls[url])
                    {
                        continue;
                    }
                    current = url;
                }
                if(current == null || count > 10)
                {
                    break;
                }

                Console.WriteLine("爬行" + current + "页面！");

                /// 使用并行（多线程）
                Task<string>[] tasks =
                {
                    Task.Run(() => Download(current)),
                    Task.Run(() => Download(current)),
                };

                string html = Download(current);

                urls[current] = true;
                count++;

                /// 对Task进行输出
                //for(int i = 0; i < tasks.Length; i++)
                //{
                //    Console.WriteLine(tasks[i].Status); // 查看状态
                //}
                //for(int i = 0; i < tasks.Length; i++)
                //{
                //    Parse(tasks[i].Result);
                //}
                //Task.WaitAll(tasks);

                Parse(html);
            }
        }

        public string Download(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[] * = * [""'][^""'#>] + [""']";
            MatchCollection matches = new Regex(strRef).Matches(html);

            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', ' ', '>');
                if(strRef.Length == 0)
                {
                    continue;
                }

                if(urls[strRef] == null)
                {
                    urls[strRef] = false;
                }
            }
        }
    }
}
