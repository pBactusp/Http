using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShareableTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Extensions;
using App.Colors;


namespace App.ViewModel
{
    public partial class McdoCodeViewModel : ObservableObject
    {
        public McdoCode _code;
        public bool _firstTime = true;

        public string Code => _code.Code;
        public string CreationDate => _code.CreationDate;
        public bool IsUsed
        {
            get { return _code.IsUsed; }
            set { _code.IsUsed = value; }
        }
        public int Id => _code.Id;


        [ObservableProperty]
        Color backgroundColor = MyColors.McdoYellow;

        [ObservableProperty]
        Color checkboxColor = MyColors.McdoRed;

        public McdoCodeViewModel(McdoCode code)
        {
            _code = code;
            BackgroundColor = IsUsed ? MyColors.McdoYellowDim : MyColors.McdoYellow;
            CheckboxColor = IsUsed ? MyColors.McdoRedDim : MyColors.McdoRed;
        }


        [RelayCommand]
        public async Task CheckboxChecked()
        {
            BackgroundColor = IsUsed ? MyColors.McdoYellowDim : MyColors.McdoYellow;
            CheckboxColor = IsUsed ? MyColors.McdoRedDim : MyColors.McdoRed;
            
            if (_firstTime)
            {
                return;
            }

            await Client.Post("editCode", new RequestParam()
            {
                Name = "id",
                Value = Id.ToString()
            },
            new RequestParam()
            {
                Name = "isUsed",
                Value = IsUsed.ToString()
            }
            );
        }
    }
}
