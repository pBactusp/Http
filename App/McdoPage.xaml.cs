using App.ViewModel;

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
            OpenAddNewPopup(null, null);
        };
	}


    private void ItemCheckboxChecked(object sender, CheckedChangedEventArgs e)
    {

    }

    private void OpenAddNewPopup(object sender, EventArgs e)
    {
        ListOfCodes.IsVisible = !ListOfCodes.IsVisible;
        NewMcdoCodeControl.IsVisible = !NewMcdoCodeControl.IsVisible;

        if (ListOfCodes.IsVisible) ExpandButton.Text = "+";
        else ExpandButton.Text = "-";
    }



    //  protected override void OnAppearing()
    //  {
    //      base.OnAppearing();
    //((McdoViewModel)BindingContext).OnAppearing();
    //  }
}