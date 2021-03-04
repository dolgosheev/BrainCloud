using System;
using System.Net.NetworkInformation;

namespace networkAdapter
{
    internal class Program
    {
        private static void Main()
        {

            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();

            Console.WriteLine("IPv4 interface information for {0}.{1}\n", properties.HostName, properties.DomainName);

            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface network in networkInterfaces)
            {
                PrintInterfaceIndex(network.Description);
            }

            Console.ReadKey();
        }

        private static void PrintInterfaceIndex(string adapterName)
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in nics)
            {
                if (adapter.Supports(NetworkInterfaceComponent.IPv4) == false)
                {
                    continue;
                }

                if (!adapter.Description.Equals(adapterName, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                Console.WriteLine("\tName        : {0}", adapter.Description);
                Console.WriteLine("\tDescription : {0}", adapter.Name);
                Console.WriteLine("\tStatus      : {0}", adapter.OperationalStatus);

                foreach (UnicastIPAddressInformation ip in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        Console.WriteLine("\tIP          : {0}", ip.Address);
                    }
                }

                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                IPv4InterfaceProperties p = adapterProperties.GetIPv4Properties();

                if (p == null)
                {
                    Console.WriteLine("No information is available for this interface.");
                    continue;
                }
                Console.WriteLine("\tNumber       : {0}\n", p.Index);
            }
        }
    }
}
