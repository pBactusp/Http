using App.Model;
using ShareableTypes;

namespace App.Controls;

public partial class McdoCodeView : ContentView
{
    static Brush unCheckedBrush;
    static Brush checkedBrush;

    public McdoCodeView()
	{
		InitializeComponent();

        unCheckedBrush = new SolidColorBrush(new Color(255, 199, 44));
        checkedBrush = new SolidColorBrush(new Color(211, 155, 0));

    }



    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		var c = BindingContext;
        ((Grid)((CheckBox)sender).Parent).Background = e.Value ? checkedBrush : unCheckedBrush;

    }
}