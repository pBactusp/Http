using CommunityToolkit.Mvvm.ComponentModel;
using ShareableTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public partial class McdoCodeModel : ObservableObject
    {
        [ObservableProperty]
        string creationDate;

        [ObservableProperty]
        string code;

        [ObservableProperty]
        bool isUsed;

        int id;

        public McdoCodeModel(McdoCode source)
        {
            creationDate = source.CreationDate;
            code = source.Code;
            isUsed = source.IsUsed;
            id = source.Id;
        }
    }
}
