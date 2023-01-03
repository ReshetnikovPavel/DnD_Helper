using DndHelper.App.ViewModels;

namespace DnD_Helper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage(RegisterViewModel registerViewModel)
        {
            InitializeComponent();
            BindingContext = registerViewModel;
        }
    }
}