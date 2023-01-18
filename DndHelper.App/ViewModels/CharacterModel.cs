using DndHelper.Domain.Dnd;
using DndHelper.Infrastructure;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DndHelper.App.ViewModels
{
    [QueryProperty(nameof(Character), nameof(Character))]
    public partial class CharacterModel : BindableObject
    {
        Character character;

        public Character Character
        {
            get => character;
            set
            {
                character = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Background));
            }
        }

        public int Level => 1;
        public string Background => Character?.Background.Name;
        public int Money => 1000;
        public string Armor => "Leather";
        public List<Armor> ArmorProficiencies => new List<Armor> { new Armor("Кождоспех"), new Armor("металлдоспех"), new Armor("словесный доспех") };
    }
}