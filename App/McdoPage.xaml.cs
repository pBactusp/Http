using App.ViewModel;

namespace App;

public partial class McdoPage : ContentPage
{
    Brush unCheckedBrush;
    Brush checkedBrush;
	public McdoPage(McdoViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

        unCheckedBrush = new SolidColorBrush(new Color(255, 199, 44));
        checkedBrush = new SolidColorBrush(new Color(211, 155, 0));
	}

    private void ItemCheckboxChecked(object sender, CheckedChangedEventArgs e)
    {
        ((Grid)((CheckBox)sender).Parent).Background = e.Value ? checkedBrush : unCheckedBrush;

    }



    //  protected override void OnAppearing()
    //  {
    //      base.OnAppearing();
    //((McdoViewModel)BindingContext).OnAppearing();
    //  }
}