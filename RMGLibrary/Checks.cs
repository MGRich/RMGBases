using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace RMGLibrary
{
    public class Checks
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
    }
}