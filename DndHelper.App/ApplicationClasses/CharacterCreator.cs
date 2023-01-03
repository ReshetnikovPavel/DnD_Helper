using DndHelper.Domain;
using DndHelper.Domain.Dnd;
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

        public CharacterCreator(IStateManager<string, object> stateManager)
        {
            this.stateManager = stateManager;
            SubscribeToMessaging();
        }

        public bool CanCreate()
        {
            return IsSelected(nameof(Race));
        }

        public Character Create()
        {
            return null;
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

