namespace DnD_Helper;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new MenuShell();
    }
}
