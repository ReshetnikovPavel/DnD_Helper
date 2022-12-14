using DnD_Helper.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DndHelper.Domain.Repositories;
using System.Windows.Input;
using DndHelper.Domain.Dnd;

namespace DnD_Helper.ViewModels
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
