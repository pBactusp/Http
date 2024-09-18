using App.ViewModel;
using ShareableTypes;
using System.ComponentModel;

namespace App.Controls;

public partial class McdoCodeView : ContentView
{
    private McdoCodeViewModel bindingContext => BindingContext as McdoCodeViewModel;
    private bool _first = true;

    public McdoCodeView()
    {
        InitializeComponent();

        this.Loaded += (s, e) =>
        {
            if (_first)
            {
                BindingContext = new ViewModel.McdoCodeViewModel(BindingContext as McdoCode);
                (BindingContext as McdoCodeViewModel)._firstTime = false;
                _first = false;
            }
        };
    }
}