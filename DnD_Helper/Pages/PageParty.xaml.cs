using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class PageParty : ContentPage
{
    public PageParty(ModelParty model)
    {
        InitializeComponent();
        BindingContext = model;
    }
}