using System.Data;

namespace App
{
    public partial class MainPage : ContentPage
    {
        HttpClient client;
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            //count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            DataLable.Text = string.Empty;
            await RequestData();
            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async Task RequestData()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                client = new HttpClient();
                using HttpResponseMessage response = await client.GetAsync("http://10.100.102.13:8080/data");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                DataLable.Text = responseBody;
            }
            catch (HttpRequestException e)
            {
                DataLable.Text = e.Message;
                //Console.WriteLine("\nException Caught!");
                //Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }

}
