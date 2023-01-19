using DndHelper.App.ViewModels;

namespace DnD_Helper
{
    public partial class JoinNewPartyPage : ContentPage
    {
        private readonly JoinNewPartyModel joinNewPartyModel;

        public JoinNewPartyPage(JoinNewPartyModel joinNewPartyModel)
        {
            this.joinNewPartyModel = joinNewPartyModel;
            BindingContext = joinNewPartyModel;
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            joinNewPartyModel.LoadCharacterNames();
        }
    }
}