using ShareableTypes;
using System.Text.Json;

namespace App.Controls;

public partial class NewMcdoCodeControl : ContentView
{
	public event Action<McdoCode> NewMcdoCodeAdded;

	public NewMcdoCodeControl()
	{
		InitializeComponent();
	}

    public void Clear()
	{
		TextBox.Text = string.Empty;
	}

    private async void AddNewCode(object sender, EventArgs e)
    {
		string code = TextBox.Text; // Add code to extract McdoCode from message

		string response = await Client.Post("newCode", new RequestParam() { Name = "code", Value = code });

		Clear();
		NewMcdoCodeAdded?.Invoke(JsonSerializer.Deserialize<McdoCode>(response));
    }
}