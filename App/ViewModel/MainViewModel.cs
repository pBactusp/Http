using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Data;

namespace App.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        string debugMessage;


        [RelayCommand]
        public async void ButtonPressed()
        {
            DebugMessage = string.Empty;
            DebugMessage = await Client.RequestData();
            await Shell.Current.GoToAsync(nameof(McdoPage));
        }
    }
}
