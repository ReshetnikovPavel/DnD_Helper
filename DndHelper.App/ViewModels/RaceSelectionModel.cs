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

        public IEnumerable<string> RaceNames => raceRepository.GetNames()
            .Where(x => !raceRepository.GetSubraceNames(x).Any()); //Пока подрасы не сделаны...

        private void OnRaceSelected(string selectedName)
        {
            MessageSender.SendSelectionMade(this, nameof(Character.Race), selectedName);
            MessageSender.SendPageCompleted<RaceSelectionModel>(this);
        }
    }
}
