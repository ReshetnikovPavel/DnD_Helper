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

        public CharacterCreator()
        {
            stateManager = new StateDictionary<string, object>();
        }

        public void SubscribeToModel<TModel>() where TModel : BindableObject
        {
            MessagingCenter.Subscribe<TModel, Selection>(
                this, MessageTypes.SelectionMade.ToString(), OnSelectionMade);
        }

        public bool CanCreate()
        {
            throw new NotImplementedException();
        }

        public Character Create()
        {
            throw new NotImplementedException();
        }

        private void OnSelectionMade(object sender, Selection selection)
        {
            stateManager.SetValue(selection.Property, selection.Value);
        }
    }
}

