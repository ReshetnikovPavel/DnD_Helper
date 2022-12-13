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
        public ICommand GoToNextPage { get; }

        public AbilityScoreSelectionModel(DistributorAbilityScore distributor)
        {
            this.distributor = distributor;
            distributor.TotalPointsUpdated += OnPointsUpdated;
            GoToNextPage = new Command(OnGoToNextPage);
        }

        public string PointsLeft
            => $"Очков осталось: {Distributor.TotalPoints}";

        public DistributorAbilityScore Distributor
            => distributor;

        public AbilityScore Charisma
            => AppShell.Singleton.Abilities.Charisma;

        public AbilityScore Constitution
            => AppShell.Singleton.Abilities.Constitution;

        public AbilityScore Dexterity
            => AppShell.Singleton.Abilities.Dexterity;

        public AbilityScore Intelligence
            => AppShell.Singleton.Abilities.Intelligence;

        public AbilityScore Strength
            => AppShell.Singleton.Abilities.Strength;

        public AbilityScore Wisdom
            => AppShell.Singleton.Abilities.Wisdom;

        
        private void OnPointsUpdated(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(PointsLeft));
        }

        private void OnGoToNextPage()
        {
            MessageSender.SendPageCompleted<AbilityScoreSelectionModel>(this);
        }
    }
}
