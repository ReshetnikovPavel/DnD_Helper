using DndHelper.App.Authentication;
using DndHelper.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DndHelper.Domain.Dnd;

namespace DnD_Helper.ViewModels
{
    public class CharacterSelectionModel : BindableObject
    {
        public ICommand SelectCharacter { get; }
        public ICommand JoinParty { get; }
        public ICommand CreateParty { get; }

        public int[] Arr
            => new int[] { 0, 1, 2, 3 };
        public Task<IEnumerable<Character>> Characters => characterRepository.GetCharacters();
        private readonly ICharacterRepository characterRepository;

        public CharacterSelectionModel(ICharacterRepository characterRepository)
        {
            this.characterRepository = characterRepository;
        }
    }
}
