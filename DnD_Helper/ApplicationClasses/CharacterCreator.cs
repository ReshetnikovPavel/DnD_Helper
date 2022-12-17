using DnD_Helper.ViewModels;
using DndHelper.Domain;
using DndHelper.Domain.Dnd;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    public class CharacterCreator : ICreatesCharacter
    {
        private IStateManager<string, object> stateManager;

        public CharacterCreator(IStateManager<string, object> stateManager)
        {
            this.stateManager = stateManager;
        }

        public void SubscribeToModel<TModel>() where TModel : BindableObject
        {
            MessagingCenter.Subscribe<TModel, Selection>(
                this, MessageTypes.SelectionMade.ToString(), OnSelectionMade);
        }

        public bool CanCreate()
        {
            return true;
        }

        public Character Create()
        {
            return null;
        }

        private void OnSelectionMade(object sender, Selection selection)
        {
            stateManager.SetValue(selection.Property, selection.Value);
        }
    }
}

