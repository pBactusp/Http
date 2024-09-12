using ShareableTypes;
using System.Net;
using System.Text.Json;

namespace MyHttp
{
    public class Server
    {
        string[] _prefixes;
        HttpListener _listener;
        CancellationTokenSource _cancellationTokenSource;

        List<McdoCode> mcdoCodes;

        public Server(string adress, string port, string[] prefixes)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("Prefixes are required.");

            _prefixes = prefixes;

            _listener = new HttpListener();
            foreach (string prefix in _prefixes)
                _listener.Prefixes.Add($"http://{adress}:{port}{prefix}");

            _cancellationTokenSource = new CancellationTokenSource();

            #region Create McdoCodes for testing
            mcdoCodes = new List<McdoCode>();
            Random rnd = new Random();
            DateTime RandomDay()
            {
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                return start.AddDays(rnd.Next(range));
            }
            for (int i = 0; i < 10; i++)
            {
                mcdoCodes.Add(new McdoCode()
                {
                    CreationDate = RandomDay().Date.ToString("d"),
                    Code = rnd.Next(99999, 1000000).ToString(),
                    IsUsed = Convert.ToBoolean(rnd.Next(2)),
                    Id = i
                });
            }
            #endregion
        }

        public void Start()
        {
            _listener.Start();
            Console.WriteLine("Listening...");

            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                var context = _listener.GetContext();
                HandleRequest(context);
            }
            
            _listener.Stop();
        }

        public async Task HandleRequest(HttpListenerContext context)
        {
            Console.WriteLine("A request has been recieved!");
            var request = context.Request;
            var response = context.Response;
            string rawUrl = request.RawUrl;
            string responseString;


            response.StatusCode = (int)HttpStatusCode.OK;

            switch (rawUrl)
            {
                case "/":
                    responseString = "<HTML><BODY>Welcome to the main page!</BODY></HTML>";
                    break;
                case "/yo":
                    responseString = "<HTML><BODY>Yo</BODY></HTML>";
                    break;
                case "/wat":
                    responseString = "<HTML><BODY>Wat</BODY></HTML>";
                    break;
                case "/data":
                    var dataPack = new DataPack()
                    {
                        Name = "Jason",
                        Age = 15,
                        Wut = new int[] { 3, 1, 2 }
                    };
                    responseString = System.Text.Json.JsonSerializer.Serialize(dataPack);
                    break;
                case "/codes":
                    responseString = JsonSerializer.Serialize(mcdoCodes);
                    Console.WriteLine(responseString);
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    responseString = "<HTML><BODY><p>404</p><br/><p>Page not found</p></BODY></HTML>";
                    Console.WriteLine($"Recieved unknown requset \"{request.Url}\".");
                    break;
            }


            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;

            using (Stream stream = response.OutputStream)
            {
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }


    public class DataPack
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int[] Wut { get; set; }
    }
}

