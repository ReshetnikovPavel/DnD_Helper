using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class MenuModel : BindableObject
    {
        public ICommand SelectMyCharacter { get; }
        public ICommand CreateNewCharacter { get; }
        public ICommand SelectMyParty { get; }
    }
}