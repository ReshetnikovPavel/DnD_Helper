using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class SkillsSelectionPage : ContentPage
{
    public SkillsSelectionPage()
    {
        InitializeComponent();

        BindingContext = new SkillsSelectionModel();
    }
}