using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace RMGLibrary
{
    public class Changelog
    {
        public static string[] getData(string r)
        {
            if (Internet.isConnected() == false) return new string[2] { "NULL", "NULL" };
            string[] data = new string[2];
            Internet.Download d = new Internet.Download();
            string url = d.getString("https://api.github.com/repos/MGRich/" + r + "/releases/latest");
        }
    }
}