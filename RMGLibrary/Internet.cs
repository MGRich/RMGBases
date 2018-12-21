using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;

namespace RMGLibrary
{
    public class Internet
    {
        public static bool isConnected()
        {
            try
            {
                Ping p = new Ping();
                if (p.Send("8.8.8.8", 1000).Status != IPStatus.Success)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public class Download
        {
            private WebClient client = new WebClient();

            public Download()
            {
                client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:65.0) Gecko/20100101 Firefox/65.0");
            }

            public Download(string u)
            {
                client.Headers.Add("user-agent", u);
            }

            public string getString(string url)
            {
                try
                {
                    return client.DownloadString(url);
                }
                catch (WebException)
                {
                    return null;
                }
            }

            public string getFile(string url, string op)
            {
                try
                {
                    client.DownloadFile(url, op);
                    return op;
                }
                catch (WebException)
                {
                    return null;
                }
            }
        }
    }
}