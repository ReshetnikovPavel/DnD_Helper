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
        public string Background => Character?.Background.Name;
        public string Armor => "Leather";
        public List<Armor> ArmorProficiencies => new List<Armor> { new Armor("Кождоспех"), new Armor("металлдоспех"), new Armor("словесный доспех") };
    }
}