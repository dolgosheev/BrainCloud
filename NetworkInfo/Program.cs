using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

var properties = IPGlobalProperties.GetIPGlobalProperties();
var interfaces = NetworkInterface.GetAllNetworkInterfaces().ToList();

Console.WriteLine("IPv4 interface information for {0}.{1}\nFound : {2} interfaces\n", properties.HostName,
    properties.DomainName, interfaces.Count);

interfaces.ForEach(adapter =>
{
    if (adapter is null) return;

    var result = new StringBuilder();
    result.AppendLine($"\t{"Name",-12} : {adapter.Name}");
    result.AppendLine($"\t{"Description",-12} : {adapter.Description}");
    result.AppendLine($"\t{"Status",-12} : {adapter.OperationalStatus}");

    adapter.GetIPProperties().UnicastAddresses.ToList().ForEach(ip =>
    {
        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
            result.AppendLine($"\t{"IP",-12} : {ip.Address}");
    });
    result.AppendLine($"\t{"Number",-12} : {adapter.GetIPProperties().GetIPv4Properties().Index}");

    Console.WriteLine(result);
});

Console.ReadKey();