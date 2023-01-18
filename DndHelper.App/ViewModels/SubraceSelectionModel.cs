using DndHelper.App.ApplicationClasses;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using System.Reflection;
using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class SubraceSelectionModel : BindableObject
    {
        public ICommand SelectSubrace { get; }
        private readonly IRaceRepository raceRepository;
        private IEnumerable<string> subraceNames;

        public SubraceSelectionModel(IRaceRepository raceRepository)
        {
            this.raceRepository = raceRepository;

            SelectSubrace = new Command<string>(OnSubraceSelected);
            MessagingCenter.Subscribe<object, AttributeSelection>(this,
                MessageTypes.SelectionMade.ToString(), SelectionMade);
            MessageSender.SendAttributeRequested(this, CharacterAttributes.Race);
        }

        public IEnumerable<string> SubraceNames
        {
            get => subraceNames;
            set
            {
                subraceNames = value;
                OnPropertyChanged();
            }
        }

        public void SelectionMade(object sender, AttributeSelection selection)
        {
            if (selection.Attribute != CharacterAttributes.Race)
                return;
            SubraceNames = raceRepository.GetSubraceNames(selection.Value as string);
        }

        private void OnSubraceSelected(string selectedName)
        {
            MessageSender.SendSelectionMade(this, CharacterAttributes.Subrace, selectedName);
            MessageSender.SendPageCompleted<SubraceSelectionModel>(this);
        }
    }
}
