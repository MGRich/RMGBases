using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using SharpCompress.Common;
using SharpCompress.Readers;
using System.Reflection;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace RMGUpdater
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool f = false;
            int id = 0;
            if (File.Exists("id")) id = int.Parse(File.ReadAllText("id"));
            WebClient c = new WebClient();
            try
            {
                Ping p = new Ping();
                if (p.Send("8.8.8.8", 1000).Status != IPStatus.Success)
                {
                    Console.WriteLine("p");
                    Environment.Exit(2);
                }
            }
            catch
            {
                Environment.Exit(1);
            }
            string repo = args[0];
            c.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:65.0) Gecko/20100101 Firefox/65.0");
            string data = c.DownloadString("https://api.github.com/repos/MGRich/" + repo + "/releases/latest");
            JObject jdata = JObject.Parse(data);
            if (id != int.Parse(jdata.SelectToken("id").ToString()))
            {
                f = true;
                id = int.Parse(jdata.SelectToken("id").ToString());
                Directory.CreateDirectory("temp");
                Directory.CreateDirectory(@"temp\ext");
                JToken asset = jdata.SelectToken("assets")[0];
                Console.WriteLine();
                c.DownloadFile(asset.SelectToken("browser_download_url").ToString(), @"temp\d");
                var reader = ReaderFactory.Open(File.OpenRead(@"temp\d"));
                while (reader.MoveToNextEntry())
                {
                    if (!reader.Entry.IsDirectory)
                    {
                        reader.WriteEntryToDirectory(@"..\", new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                    }
                }
                reader.Cancel();
                reader.Dispose();
                Directory.Delete(@"temp", true);
                using (Stream s = File.OpenWrite("id"))
                {
                    s.Flush();
                    s.Write(Encoding.Default.GetBytes(id.ToString()), 0, id.ToString().Length);
                }
            }
            Console.WriteLine("done");
            if (!f) Console.WriteLine("no change");
            Console.WriteLine(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            Process process = new Process();
            {
                process.StartInfo.FileName = repo;
                process.StartInfo.Arguments = "1";
                process.StartInfo.WorkingDirectory = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            }
            process.Start();
            Environment.Exit(0);
        }
    }
}