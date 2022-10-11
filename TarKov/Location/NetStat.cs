using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
public static class NetStat
{
    public static void Test()
    {
        IPGlobalProperties ipProp = IPGlobalProperties.GetIPGlobalProperties();
        IPEndPoint[] endPoits = ipProp.GetActiveTcpListeners();
        TcpConnectionInformation[] tcpConnections = ipProp.GetActiveTcpConnections();
        foreach (var info in tcpConnections)
        {
            Console.WriteLine("Local:" + info.LocalEndPoint.Address.ToString());
        }
    }
}