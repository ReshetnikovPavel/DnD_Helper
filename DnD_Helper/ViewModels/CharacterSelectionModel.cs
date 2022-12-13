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
        public ICommand JoinParty { get; }
        public ICommand CreateParty { get; }

        public int[] Arr
            => new int[] { 0, 1, 2, 3 };


    }
}
