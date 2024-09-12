using MyHttp;
using ShareableTypes;
using System.Security.Cryptography;

string[] prefixes = new string[]
{
    "/",
    "/yo/",
    "/wat/",
    "/data/",
    "/codes/"
};



//Console.WriteLine(IPAddress.Broadcast.ToString());
Server server = new Server("+", "8080", prefixes);
server.Start();



