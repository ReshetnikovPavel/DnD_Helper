using System.Windows.Input;

namespace DnD_Helper;

public partial class AppShell : Shell
{
	public ICommand GoBack { get; }
    public ICommand GoForward { get; }

    public AppShell()
	{
		InitializeComponent();

        GoBack = new Command(OnGoBack, CanGoBack);
        GoForward = new Command(OnGoForward, CanGoForward);
        
        BindingContext = this;
	}

    private void BackToMenu_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new MenuShell();
    }

    private void OnGoBack() { App.Current.MainPage = new MenuShell(); }

    private bool CanGoBack() { return true; }

    private void OnGoForward() { }

    private bool CanGoForward() { return true; }

    protected override bool OnBackButtonPressed()
    {
        GoBack.Execute(null);
        return true;
    }
}
