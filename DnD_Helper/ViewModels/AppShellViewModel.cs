﻿using DnD_Helper.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DnD_Helper.ViewModels
{
    public class AppShellViewModel : BindableObject
    {
        public ICommand GoToCharacterSheet { get; }
        private readonly ICreatesCharacter creator;
        private readonly CharacterCreationNavigator navigator;

        public AppShellViewModel(ICreatesCharacter creator, CharacterCreationNavigator navigator)
        {
            this.creator = creator;
            this.navigator = navigator;
            GoToCharacterSheet = new Command(navigator.TryGoToCharacterSheet);
            AddModels();
        }

        private void AddModels()
        {
            AddModel<RaceSelectionModel>();
            AddModel<ClassSelectionModel>();
            AddModel<AbilityScoreSelectionModel>();
            AddModel<BackgroundSelectionModel>();
        }

        private void AddModel<TModel>() where TModel : BindableObject
        {
            creator.SubscribeToModel<TModel>();
            navigator.AddModel<TModel>();
        }
    }
}
