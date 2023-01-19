using DndHelper.App.ApplicationClasses;
using DndHelper.Domain.Repositories;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class AbilityRaceBonusSelectionModel : BindableObject
    {
        public ICommand SelectAbilityRaceBonus{ get;}
        private IRaceRepository raceRepository;
        private int numberOfAbilityRaceBonuses;
        private string raceName;
        private string subraceName;

        public AbilityRaceBonusSelectionModel(IRaceRepository raceRepository)
        {
            SelectAbilityRaceBonus = new Command(SelectAbilityRaceBonusTapped);
            this.raceRepository = raceRepository;

            MessagingCenter.Subscribe<object, AttributeSelection>(this,
                MessageTypes.SelectionMade.ToString(), SelectionMade);
            MessageSender.SendAttributeRequested(this, CharacterAttributes.Race);
            MessageSender.SendAttributeRequested(this, CharacterAttributes.Race);
        }
        
        public void SelectAbilityRaceBonusTapped(object obj)
        {
            return;
        }

        public int NumberOfAbilityRaceBonuses
        {
            get => numberOfAbilityRaceBonuses;
            set
            {
                numberOfAbilityRaceBonuses = value;
                OnPropertyChanged();
            }
        }

        public void SelectionMade(object sender, AttributeSelection selection)
        {
            if (selection.Attribute == CharacterAttributes.Race)
                raceName = selection.Value as string;
            else if (selection.Attribute == CharacterAttributes.Subrace)
                subraceName = selection.Value as string;
            else
                return;
        }


        public string[] Abilities
            => new string[] { "Сила", "Ловкость", "Телосложение", "Интеллект", "Мудрость", "Харизма" };
    }
}
