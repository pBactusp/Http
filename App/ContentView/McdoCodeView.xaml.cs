using App.Model;
using ShareableTypes;

namespace App.Controls;

public partial class McdoCodeView : ContentView
{
    static Color unCheckedColor = new Color(255, 199, 44);
    static Color checkedColor = new Color(211, 155, 0);
    bool _firstTime = true;

    public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(McdoCodeView), unCheckedColor);

    public Color BackgroundColor
    {
        get => GetValue(BackgroundColorProperty) as Color;
        set => SetValue(BackgroundColorProperty, value);
    }

    public McdoCodeView()
    {
        InitializeComponent();

        this.Loaded += (s, e) => { _firstTime = false; };

    }



    private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var c = BindingContext as McdoCode;
        BackgroundColor = e.Value ? checkedColor : unCheckedColor;

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