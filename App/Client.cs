namespace App
{
    public static class Client
    {
        static HttpClient _client;

        static Client()
        {
            _client = new HttpClient();
        }

        public static async Task<string> RequestData()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                _client = new HttpClient();
                using HttpResponseMessage response = await _client.GetAsync($"http://10.60.41.144:8080/data");
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
