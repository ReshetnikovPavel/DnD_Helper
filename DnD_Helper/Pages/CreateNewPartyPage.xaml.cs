using DndHelper.App.ViewModels;

namespace DnD_Helper
{
    public partial class CreateNewPartyPage : ContentPage
    {
        public CreateNewPartyPage(CreateNewPartyModel createNewPartyModel)
        {
            InitializeComponent();

            BindingContext = createNewPartyModel;
        }
    }
}