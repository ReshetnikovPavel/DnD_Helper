using DndHelper.App.ApplicationClasses;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class RaceSelectionModel : BindableObject
    {
        public ICommand SelectRace { get; }
        private readonly IRaceRepository raceRepository;

        public RaceSelectionModel(IRaceRepository raceRepository)
        {
            this.raceRepository = raceRepository;

            SelectRace = new Command<string>(OnRaceSelected);
        }

        public IEnumerable<string> RaceNames => raceRepository.GetNames();

        private void OnRaceSelected(string selectedName)
        {
            MessageSender.SendSelectionMade(this, CharacterAttributes.Race, selectedName);
            MessageSender.SendPageCompleted<RaceSelectionModel>(this);
        }
    }
}
