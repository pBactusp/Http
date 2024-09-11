using App.ViewModel;
using System.Data;

namespace App
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        //private async void OnCounterClicked(object sender, EventArgs e)
        //{
        //    DataLable.Text = string.Empty;
        //    DataLable.Text = await Client.RequestData();
        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}

        
    }

}
