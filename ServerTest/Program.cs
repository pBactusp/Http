using MyHttp;

string[] prefixes = new string[]
{
    "/",
    "/yo/",
    "/wat/",
    "/data/",
    "/codes/",
    "/editCode/",
    "/newCode/"
};



//Console.WriteLine(IPAddress.Broadcast.ToString());
Server server = new Server("+", "8080", prefixes);
server.Start();



