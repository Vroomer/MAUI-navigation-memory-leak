using System.Collections.ObjectModel;

namespace MauiApp8;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
        for (int i = 0; i < 500; i++)
        {
            MemoryCollection.Add(new byte[2048]);
        }
        BindingContext = this;
	}

    private ObservableCollection<byte[]> _memoryCollection = new();

    public ObservableCollection<byte[]> MemoryCollection
    {
        get { return _memoryCollection; }
        set { _memoryCollection = value; }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        //Shell.Current.GoToAsync("..");
    }
}