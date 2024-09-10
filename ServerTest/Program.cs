using MyHttp;
using System.Net;

string[] prefixes = new string[]
{
    "/",
    "/yo/",
    "/wat/",
    "/data/"
};

//Console.WriteLine(IPAddress.Broadcast.ToString());
Server server = new Server("+", 8080, prefixes);
server.Start();
