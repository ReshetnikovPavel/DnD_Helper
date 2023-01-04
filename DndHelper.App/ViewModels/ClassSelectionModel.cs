using System.Windows.Input;
using DndHelper.App.ApplicationClasses;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;

namespace DndHelper.App.ViewModels
{
    public class ClassSelectionModel : BindableObject
    {
        public ICommand SelectClass { get; }
        private IClassRepository classRepository;

        public ClassSelectionModel(IClassRepository classRepository)
        {
            this.classRepository = classRepository;

            SelectClass = new Command<string>(OnClassSelected);
        }

        public IEnumerable<string> ClassNames => classRepository.GetNames();

        private void OnClassSelected(string selectedName)
        {
            MessageSender.SendSelectionMade(this, nameof(Character.Class), selectedName);
            MessageSender.SendPageCompleted<ClassSelectionModel>(this);
        }
    }
}
