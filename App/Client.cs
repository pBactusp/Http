namespace App
{
    public static class Client
    {
        static HttpClient _client;
        static string _targetIp = "10.100.102.13";

        static Client()
        {
            _client = new HttpClient();
        }

        public static async Task<string> RequestData(string path)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                _client = new HttpClient();
                using HttpResponseMessage response = await _client.GetAsync($"http://{_targetIp}:8080/{path}");
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
