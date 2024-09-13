using App.Model;
using ShareableTypes;

namespace App.Controls;

public partial class McdoCodeView : ContentView
{
    static Brush unCheckedBrush;
    static Brush checkedBrush;
    bool _firstTime = true;

    public McdoCodeView()
    {
        InitializeComponent();

        unCheckedBrush = new SolidColorBrush(new Color(255, 199, 44));
        checkedBrush = new SolidColorBrush(new Color(211, 155, 0));

        this.Loaded += (s, e) => { _firstTime = false; };

    }



    private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var c = BindingContext as McdoCode;
        ((Grid)((CheckBox)sender).Parent).Background = e.Value ? checkedBrush : unCheckedBrush;

        if (_firstTime)
        {
            return;
        }

        await Client.Post("editCode", new RequestParam()
        {
            Name = "id",
            Value = c.Id.ToString()
        },
        new RequestParam()
        {
            Name = "isUsed",
            Value = c.IsUsed.ToString()
        }
        );

    }
}