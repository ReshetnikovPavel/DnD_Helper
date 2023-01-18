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

        public CharacterCreator(IStateManager<string, object> stateManager, RepositoryFacade repositoryFacade, ICharacterRepository<HttpStatusCode> characterRepository)
        {
            this.characterRepository = characterRepository;
            StateManager = stateManager;
            RepositoryFacade = repositoryFacade;
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
            var raceName = StateManager.GetValue(nameof(Character.Race)) as string;
            var className = StateManager.GetValue(nameof(Character.Class)) as string;
            var abilities = StateManager.GetValue(nameof(Character.Abilities)) as Abilities;
            var name = StateManager.GetValue(nameof(Character.Name)) as string;
            var backgroundName = StateManager.GetValue(nameof(Character.Background)) as string;


            var character = new Character(abilities);
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

        private bool IsSelected(string attributeName)
        {
            return StateManager.HasKey(attributeName);
        }
    }
}
