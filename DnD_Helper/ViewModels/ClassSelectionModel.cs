using DnD_Helper.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Windows.Input;

namespace DnD_Helper.ViewModels
{
    public class ClassSelectionModel : BindableObject
    {
        public ICommand SelectClass { get; }

        public ClassSelectionModel() 
        {
            SelectClass = new Command<string>(OnClassSelected);
        }

        public IEnumerable<string> ClassNames
        => AppShell.Singleton.ClassRepository.GetNames();

        private void OnClassSelected(string selectedName)
        {
            MessagingCenter.Send(this, Messages.AttributeSelected.ToString(),
                new Selection(nameof(Class), selectedName));
            MessagingCenter.Send<BindableObject, string>(this, Messages.PageCompleted.ToString(),
                nameof(ClassSelectionModel));
        }
    }
}
