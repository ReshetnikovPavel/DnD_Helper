using DndHelper.Domain;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.App.ApplicationClasses
{
    public class CharacterCreator : ICreatesCharacter
    {
        private IStateManager<string, object> stateManager;

        public CharacterCreator(IStateManager<string, object> stateManager, IRaceRepository raceRepository)
        {
            this.stateManager = stateManager;
            SetDefaultValues();
            SubscribeToMessaging();
        }

        public bool CanCreate()
        {
            return IsSelected(nameof(Character.Race))
                && IsSelected(nameof(Character.Class))
                && IsSelected(nameof(Character.Background))
                && IsSelected(nameof(Character.Abilities))
                && IsSelected(nameof(Character.Name));

        }

        public Character Create()
        {
            var race = stateManager.GetValue(nameof(Character.Race)) as string;
            var dndClass = stateManager.GetValue(nameof(Character.Class)) as string;
            var abilities = stateManager.GetValue(nameof(Character.Abilities)) as string;
            var name = stateManager.GetValue(nameof(Character.Name)) as string;
            var background = stateManager.GetValue(nameof(Character.Background)) as string;
            

            var character = new Character();
            character.ApplyRace(race);
            character.ApplyClass(dndClass);
            character.ApplyAbilities(abilities);
            character.Name = name;
            character.ApplyBackground(background);

            return character;
        }

        private void SetDefaultValues()
        {
            stateManager.SetValue(nameof(Character.Abilities), Abilities.CreateDefault());
        }

        private void SubscribeToMessaging()
        {
            MessagingCenter.Subscribe<object, Selection>(this, 
                MessageTypes.SelectionMade.ToString(), OnSelectionMade);
        }

        private void OnSelectionMade(object sender, Selection selection)
        {
            stateManager.SetValue(selection.Property, selection.Value);
        }

        private bool IsSelected(string attributeName)
        {
            return stateManager.HasKey(attributeName);
        }
    }
}

