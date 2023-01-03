using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DnD_Helper.ViewModels
{
    class CharacterSelectionModel : BindableObject
    {
        public ICommand SelectCharacter { get; }
        public ICommand CreateNewCharacter { get; }

        public string[] CharacterNames
            => new string[] {"Люля", "Пельмешек", "Поль Реш", "Синий", "Симонов"};


    }
}
