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
        public static string[][] getData(string r, int history)
        {
            if (Internet.isConnected() == false) return null;
            if (history < 0) throw new ArgumentOutOfRangeException("history");
            List<string[]> data = new List<string[]>();
            Internet.Download d = new Internet.Download();
            string s = d.getString("https://api.github.com/repos/MGRich/" + r + "/releases");
            if (s == null) return new string[1][] { new string[2] { "If you see this, a network error ocurred. (Possibly a 403.)", "" } };
            JArray jdata = JArray.Parse(s);
            List<string> intl = new List<string>();
            foreach (JObject o in jdata.Children<JObject>())
            {
                intl.Add(o.GetValue("id").ToString());
                Console.WriteLine(o.GetValue("id"));
            }
            //intl.Reverse();
            if (history == 0) history = intl.Count();
            for (int i = 0; i < history; i++)
            {
                data.Add(getData(r, intl[i]));
            }
            return data.ToArray();
        }

        public static string[] getData(string r)
        {
            if (Internet.isConnected() == false) return null;
            Internet.Download d = new Internet.Download();
            string id = JObject.Parse(d.getString("https://api.github.com/repos/MGRich/" + r + "/releases/latest")).GetValue("id").ToString();
            return getData(r, id);
        }

        private static string[] getData(string r, string id)
        {
            string[] data = new string[2];
            Internet.Download d = new Internet.Download();
            string s = d.getString("https://api.github.com/repos/MGRich/" + r + "/releases/" + id);
            //Console.WriteLine(s);
            JObject jdata = JObject.Parse(s);
            data[0] = jdata.GetValue("name").ToString();
            data[1] = jdata.GetValue("body").ToString();
            return data;
        }
    }
}