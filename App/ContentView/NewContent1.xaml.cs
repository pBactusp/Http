using CommunityToolkit.Mvvm.ComponentModel;

namespace App.Controls;

public partial class NewContent1 : ContentView
{
	public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(NewContent1), "Default title");

	public NewContent1()
	{
		InitializeComponent();
	}

	public string Title
	{
		get => GetValue(TitleProperty) as string;
		set => SetValue(TitleProperty, value);
	}
}