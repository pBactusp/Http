using App.ViewModel;
using ShareableTypes;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace App;

public partial class McdoPage : ContentPage
{
    public McdoPage(McdoViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

        NewMcdoCodeControl.NewMcdoCodeAdded += (mcdoCode) =>
        {
            vm.Codes.Add(mcdoCode);
            vm.OpenAddNewCodePopup();
        };

        Task.Run(async () => {
            await vm.LoadCodes();
        });
    }

    private void OpenAddNewPopup(object sender, EventArgs e)
    {
        ListOfCodes.IsVisible = !ListOfCodes.IsVisible;
        NewMcdoCodeControl.IsVisible = !NewMcdoCodeControl.IsVisible;

        if (ListOfCodes.IsVisible) ExpandButton.Text = "+";
        else ExpandButton.Text = "-";
    }
}