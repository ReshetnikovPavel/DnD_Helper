using DndHelper.Domain;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.App.ApplicationClasses
{
    public class CharacterCreator : ICreatesCharacter
    {
        private readonly ICharacterRepository<HttpStatusCode> characterRepository;
        private IStateManager<string, object> StateManager { get; }
        private RepositoryFacade RepositoryFacade { get; }

        private Dictionary<string, Func<bool>> attributes;

    public CharacterCreator(IStateManager<string, object> stateManager, RepositoryFacade repositoryFacade, ICharacterRepository<HttpStatusCode> characterRepository)
        {
            this.characterRepository = characterRepository;
            StateManager = stateManager;
            RepositoryFacade = repositoryFacade;
            SetDefaultValues();
            SubscribeToMessaging();
            attributes = new Dictionary<string, Func<bool>>();
        }

        public bool CanCreate()
        {
            return !attributes.Any(pair => MustSelect(pair.Key));

        }

        public bool MustSelect(string attribute)
        {
            return CanSelect(attribute) && !IsSelected(attribute);
        }

        public void AddAttribute(string attribute, Func<bool> canSelect)
        {
            attributes.Add(attribute, canSelect);
        }

        public Character Create()
        {
            var raceName = StateManager.GetValue(nameof(Character.Race)) as string;
            var className = StateManager.GetValue(nameof(Character.Class)) as string;
            var abilities = StateManager.GetValue(nameof(Character.Abilities)) as Abilities;
            var name = StateManager.GetValue(nameof(Character.Name)) as string;
            var backgroundName = StateManager.GetValue(nameof(Character.Background)) as string;


            var character = Character.CreateNew(abilities);
            character.ApplyRace(RepositoryFacade.GetRace(raceName, null));
            character.ApplyClass(RepositoryFacade.GetClass(className));
            character.Name = name;
            character.ApplyBackground(RepositoryFacade.GetBackground(backgroundName));

            characterRepository.PutCharacter(character);
            return character;
        }

        private void SetDefaultValues()
        {
            StateManager.SetValue(nameof(Character.Abilities), Abilities.CreateDefault());
        }

        private void SubscribeToMessaging()
        {
            MessagingCenter.Subscribe<object, Selection>(this,
                MessageTypes.SelectionMade.ToString(), OnSelectionMade);
        }

        private void OnSelectionMade(object sender, Selection selection)
        {
            StateManager.SetValue(selection.Property, selection.Value);
        }

        private bool CanSelect(string attributeName)
        {
            return attributes[attributeName]();
        }

        private bool IsSelected(string attributeName)
        {
            return StateManager.HasKey(attributeName);
        }

        public bool MustSelect(KeyValuePair<string, Func<bool>> attribute)
        {
            throw new NotImplementedException();
        }
    }
}
