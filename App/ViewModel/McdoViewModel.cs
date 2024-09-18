using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShareableTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.ViewModel
{
    public partial class McdoViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<McdoCode> codes;

        [ObservableProperty]
        bool isBusy = true;

        [ObservableProperty]
        bool isDisplayingAllCodes = false;

        [ObservableProperty]
        bool isAddingNewCode = false;

        [ObservableProperty]
        string expandButtonText = "+";

        public McdoViewModel()
        {

        }


        public async Task LoadCodes()
        {
            IsDisplayingAllCodes = false;
            IsAddingNewCode = false;
            IsBusy = true;

            await Task.Delay(1000);

            if (!await RequestCodesAsync())
            {
                throw new Exception("Failed to retrieve codes!");
            }

            IsBusy = false;
            IsDisplayingAllCodes = true;
        }
        private async Task<bool> RequestCodesAsync()
        {
            try
            {
                string jsonData = await Client.Get("codes");
                Codes = JsonSerializer.Deserialize<ObservableCollection<McdoCode>>(jsonData);
                return Codes != null;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [RelayCommand]
        public void OpenAddNewCodePopup()
        {
            IsDisplayingAllCodes = !IsDisplayingAllCodes;
            IsAddingNewCode = !IsAddingNewCode;

            if (IsDisplayingAllCodes) ExpandButtonText = "+";
            else ExpandButtonText = "-";
        }
    }
}
