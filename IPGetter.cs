using System;
using System.Net;

public class IPGetter
{
	static void Main(string[] args)
	{
		if(args.Length < 1) return;
		
		for(int i = 0; i < args.Length; i++)
		{
			string hostName = args[i];
			PrintHostnameIPs(hostName);
		}
		
	}
	
	static void PrintHostnameIPs(string hostName)
	{
		// Domain name resolution : try to get ip addresses pointing to the hostname :
		IPAddress[] hostNameIPs = new IPAddress[0];
		try
		{
			hostNameIPs = Dns.GetHostAddresses(hostName);
		}
		catch(Exception e)
		{
			// what happens when the passed host name is invalid or connection is broken
			Console.WriteLine("Cannot establish connection to the HostName provided");
			Console.WriteLine("Ensure an active internet connection exists and the hostname is valid");
			
			return;
		}


		// Display results : 
		// Print out the host name : 
		Console.WriteLine("");
		Console.WriteLine($"  {hostName}");
		Console.WriteLine("");
		
		// Print out every ip address of the host name : 
		for(int i = 0; i < hostNameIPs.Length; i++)
		{
			IPAddress currentIP = hostNameIPs[i];
			
			Console.WriteLine($"	IP #{i + 1} ");
			Console.WriteLine($"					IP Address		{currentIP}");
			Console.WriteLine("	");
		}
		
	}
	
	
}
