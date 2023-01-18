using DndHelper.App.ApplicationClasses;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using System.Windows.Input;


namespace DndHelper.App.ViewModels
{
    public class BackgroundSelectionModel : BindableObject
    {
        public ICommand SelectBackground { get; }
        public ICommand ChangeName { get; }
        public ICommand ClickNextButton { get; }

        private readonly IBackgroundRepository backgroundRepository;

        public BackgroundSelectionModel(IBackgroundRepository backgroundRepository)
        {
            this.backgroundRepository = backgroundRepository;

            SelectBackground = new Command<string>(OnBackgroundSelected);
            ChangeName = new Command<TextChangedEventArgs>(OnNameChanged);
            ClickNextButton = new Command(OnNextButtonClicked);
        }

        public IEnumerable<string> BackgroundNames => backgroundRepository.GetNames();

        private void OnBackgroundSelected(string selectedName)
        {
            MessageSender.SendSelectionMade(this, CharacterAttributes.Background, selectedName);
        }

        private void OnNameChanged(TextChangedEventArgs e)
        {
            MessageSender.SendSelectionMade(this, CharacterAttributes.Name, e.NewTextValue);
        }

        private void OnNextButtonClicked()
        {
            MessageSender.SendPageCompleted<BackgroundSelectionModel>(this);
        }
    }
}
