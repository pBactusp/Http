using App.Model;

namespace App.Controls;

public partial class McdoCodeView : ContentView
{
	public McdoCodeView(McdoCodeModel m)
	{
		InitializeComponent();
		BindingContext = m;
	}
}