using DndHelper.App.ApplicationClasses;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class SubraceSelectionModel : BindableObject
    {
        public ICommand SelectSubrace { get; }
        private readonly IRaceRepository raceRepository;

        public SubraceSelectionModel(IRaceRepository raceRepository)
        {
            this.raceRepository = raceRepository;

            SelectSubrace = new Command<string>(OnSubraceSelected);
        }

        public IEnumerable<string> SubraceNames => raceRepository.GetNames();

        private void OnSubraceSelected(string selectedName)
        {
            //MessageSender.SendSelectionMade(this, "Subrace", selectedName);
            //MessageSender.SendPageCompleted<SubraceSelectionModel>(this);
        }
    }
}
