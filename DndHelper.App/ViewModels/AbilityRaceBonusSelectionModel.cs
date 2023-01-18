using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class AbilityRaceBonusSelectionModel : BindableObject
    {
        public ICommand SelectAbilityRaceBonus{ get;}

        public AbilityRaceBonusSelectionModel()
        {
            SelectAbilityRaceBonus = new Command(SelectAbilityRaceBonusTapped);
        }
        
        public void SelectAbilityRaceBonusTapped(object obj)
        {
            return;
        }

        public int NumberOfAbilityRaceBonuses => 2;

        public string[] Abilities
            => new string[] { "Сила", "Ловкость", "Телосложение", "Интеллект", "Мудрость", "Харизма" };
    }
}
