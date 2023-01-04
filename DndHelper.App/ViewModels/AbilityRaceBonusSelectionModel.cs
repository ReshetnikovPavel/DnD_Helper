using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class AbilityRaceBonusSelectionModel : BindableObject
    {
        public ICommand SelectAbilityRaceBonus{ get; set;} 

        public int NumberOfAbilityRaceBonuses => 2;

        public string[] Abilities
            => new string[] { "Сила", "Ловкость", "Телосложение", "Интеллект", "Мудрость", "Харизма" };
    }
}
