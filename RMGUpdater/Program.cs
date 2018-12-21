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
            bool y = false;
            int id = 0;
            string r = args[0];
            if (File.Exists("id")) id = int.Parse(File.ReadAllText("id"));
            WebClient c = new WebClient();
            c.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:65.0) Gecko/20100101 Firefox/65.0");
            string data = null;
            try
            {
                data = c.DownloadString("https://api.github.com/repos/MGRich/" + r + "/releases/latest");
            }
            catch (WebException)
            {
                start(r, 3);
            }
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
                        try
                        {
                            reader.WriteEntryToDirectory(@"..\", new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                        }
                        catch (IOException)
                        {
                            Console.WriteLine("could not write, continuing...");
                            y = true;
                        }
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
            if (!y) start(r, 0); else start(r, 2);
        }

        private static void start(string r, int e = 0)
        {
            Process process = new Process();
            {
                process.StartInfo.FileName = r;
                process.StartInfo.Arguments = e.ToString();
                process.StartInfo.WorkingDirectory = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            }
            process.Start();
            Environment.Exit(e);
        }
    }
}