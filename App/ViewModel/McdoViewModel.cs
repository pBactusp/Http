using CommunityToolkit.Mvvm.ComponentModel;
using ShareableTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    public partial class McdoViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<McdoCode> codes;

        public McdoViewModel()
        {
            Codes = new ObservableCollection<McdoCode>();

            Codes.Add(new McdoCode()
            {
                CreationDate = "1.2.1993",
                Code = "123456",
                IsUsed = false,
                Id = 0
            });
            Codes.Add(new McdoCode()
            {
                CreationDate = "21.12.2001",
                Code = "111111",
                IsUsed = true,
                Id = 1
            });
            Codes.Add(new McdoCode()
            {
                CreationDate = "15.8.2014",
                Code = "123123",
                IsUsed = false,
                Id = 2
            });
        }


        public async Task ItemCheckboxChecked(object sender, EventArgs e)
        {

        }
    }
}
