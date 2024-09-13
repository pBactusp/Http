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

        public int Id;

        public McdoCodeModel(McdoCode source)
        {
            creationDate = source.CreationDate;
            code = source.Code;
            isUsed = source.IsUsed;
            Id = source.Id;
        }
    }
}
