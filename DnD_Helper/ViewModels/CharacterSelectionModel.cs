using DndHelper.App.Authentication;
using DndHelper.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DndHelper.Domain.Dnd;
using System.ComponentModel;

namespace DnD_Helper.ViewModels
{
    public class CharacterSelectionModel : BindableObject
    {
        public ICommand SelectCharacter { get; }
        public ICommand JoinParty { get; }
        public ICommand CreateParty { get; }
        public ICommand FillCharacterNames { get; }

        public int[] Arr
            => new int[] { 0, 1, 2, 3 };
        private IEnumerable<string> characterNames;
        public IEnumerable<string> CharacterNames 
        { 
            get => characterNames; set
            {
                characterNames = value;
                OnPropertyChanged(nameof(CharacterNames));
            }
        }
        private readonly ICharacterRepository characterRepository;

        private async void OnFillCharacterNames()
        {
            CharacterNames = (await characterRepository.GetCharacters()).Select(x => x.Name);
        }

        public CharacterSelectionModel(ICharacterRepository characterRepository)
        {
            this.characterRepository = characterRepository;
            FillCharacterNames = new Command(OnFillCharacterNames);
        }
    }
}
