using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RMGLibrary
{
    public class Changelog
    {
        public static string[][] getData(string r, int history = 1)
        {
            if (Internet.isConnected() == false) return null;
            if (history < 1) throw new ArgumentOutOfRangeException("history");
            List<string[]> data = new List<string[]>();
            Internet.Download d = new Internet.Download();
            JObject jdata = JObject.Parse(d.getString("https://api.github.com/repos/MGRich/" + r + "/releases"));
            for (int i = 0; i < history; i++)
            {
                data.Add(getData(r, JObject.Parse(jdata[i].ToString()).GetValue("id").ToString()));
            }
            return data.ToArray();
        }

        private static string[] getData(string r, string id)
        {
            string[] data = new string[2];
            Internet.Download d = new Internet.Download();
            JObject jdata = JObject.Parse(d.getString("https://api.github.com/repos/MGRich/" + r + "/releases/" + id));
            data[0] = jdata.GetValue("name").ToString();
            data[1] = jdata.GetValue("body").ToString();
            return data;
        }
    }
}