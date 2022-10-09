using System.Diagnostics;

namespace MauiApp8;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var page = new NewPage1();
        _pageWeakRefs.Add(new WeakReference(page));
        _collectionsWeakRefs.Add(new WeakReference(page.MemoryCollection));
        await Navigation.PushAsync(page);
        //Shell.Current.GoToAsync(nameof(NewPage1));
    }

    List<WeakReference> _pageWeakRefs = new();
    List<WeakReference> _collectionsWeakRefs = new();
    public string Output { get; set; }
    private void Button_Clicked_1(object sender, EventArgs e)
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        Output = "";
        int count = 0;
        foreach (var i in _pageWeakRefs)
        {
            ++count;
            Output += $"is page {count} alive: {i.IsAlive}; is its collection alive: {(_collectionsWeakRefs[(count-1)]).IsAlive}\r\n";
        }
        outputBox.Text = Output;
    }
}

