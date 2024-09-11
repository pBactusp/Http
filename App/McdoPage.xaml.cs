using App.ViewModel;

namespace App;

public partial class McdoPage : ContentPage
{
	public McdoPage(McdoViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}