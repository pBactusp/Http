using App.ViewModel;

namespace App;

public partial class McdoPage : ContentPage
{
    
	public McdoPage(McdoViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

        
	}


    private void ItemCheckboxChecked(object sender, CheckedChangedEventArgs e)
    {

    }



    //  protected override void OnAppearing()
    //  {
    //      base.OnAppearing();
    //((McdoViewModel)BindingContext).OnAppearing();
    //  }
}