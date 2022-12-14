using DnD_Helper.ApplicationClasses;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DnD_Helper.ViewModels
{
    public class AbilityScoreSelectionModel : BindableObject
    {
        private DistributorAbilityScore distributor;
        private Abilities abilities;
        public ICommand GoToNextPage { get; }

        public AbilityScoreSelectionModel(DistributorAbilityScore distributor)
        {
            this.distributor = distributor;
            abilities = Abilities.CreateDefault();
            distributor.TotalPointsUpdated += OnPointsUpdated;
            GoToNextPage = new Command(OnGoToNextPage);
        }

        public string PointsLeft
            => $"Очков осталось: {Distributor.TotalPoints}";

        public DistributorAbilityScore Distributor
            => distributor;

        public AbilityScore Charisma
            => abilities.Charisma;

        public AbilityScore Constitution
            => abilities.Constitution;

        public AbilityScore Dexterity
            => abilities.Dexterity;

        public AbilityScore Intelligence
            => abilities.Intelligence;

        public AbilityScore Strength
            => abilities.Strength;

        public AbilityScore Wisdom
            => abilities.Wisdom;
        
        private void OnPointsUpdated(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(PointsLeft));
            MessageSender.SendSelectionMade(this, nameof(Character.Abilities), abilities);
        }

        private void OnGoToNextPage()
        {
            MessageSender.SendPageCompleted<AbilityScoreSelectionModel>(this);
        }
    }
}
