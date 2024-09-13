using System.Web;

namespace App
{
    public class RequestParam
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public static class Client
    {
        static HttpClient _client;
        static string _targetIp = "10.100.102.13";

        static Client()
        {
            _client = new HttpClient();
        }

        public static async Task<string> Get(string path, params RequestParam[] parameters)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                foreach ( var param in parameters ) query[param.Name] = param.Value;
                var q = query.ToString();
                _client = new HttpClient();
                using HttpResponseMessage response = await _client.GetAsync($"http://{_targetIp}:8080/{path}{(q != string.Empty ? "?"+q : q)}");//$"http://{_targetIp}:8080/{path}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                return e.Message;
            }
        }
        public static async Task<string> Post(string path, params RequestParam[] parameters)
        {
            try
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                foreach (var param in parameters) query[param.Name] = param.Value;
                var q = query.ToString();
                _client = new HttpClient();
                using HttpResponseMessage response = await _client.PostAsync($"http://{_targetIp}:8080/{path}{(q != string.Empty ? "?" + q : q)}", null);//$"http://{_targetIp}:8080/{path}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                return e.Message;
            }
        }
    }
}
