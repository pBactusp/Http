using CommunityToolkit.Mvvm.ComponentModel;
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

        public McdoViewModel()
        {
            LoadCodes();

        }
         
        public async void LoadCodes()
        {
            if (!await RequestCodesAsync())
            {
                
            }

        }
        public async Task<bool> RequestCodesAsync()
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

        public async Task ItemCheckboxChecked(object sender, EventArgs e)
        {

        }
    }
}
