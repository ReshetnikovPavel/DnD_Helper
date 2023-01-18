﻿using DndHelper.Domain;
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
        private IStateManager<CharacterAttributes, object> StateManager { get; }

        private readonly ICharacterRepository<HttpStatusCode> characterRepository;
        private RepositoryFacade RepositoryFacade { get; }

        private Dictionary<CharacterAttributes, Func<bool>> attributes
            = new Dictionary<CharacterAttributes, Func<bool>>
            {
                [CharacterAttributes.Race] = () => { return true; },
                [CharacterAttributes.Class] = () => { return true; },
                [CharacterAttributes.Abilities] = () => { return true; },
                [CharacterAttributes.Name] = () => { return true; },
                [CharacterAttributes.Background] = () => { return true; },
                [CharacterAttributes.Subrace] = () => { return false; }
            };

        public CharacterCreator(IStateManager<CharacterAttributes, object> stateManager, RepositoryFacade repositoryFacade, ICharacterRepository<HttpStatusCode> characterRepository)
        {
            this.characterRepository = characterRepository;
            StateManager = stateManager;
            RepositoryFacade = repositoryFacade;
            SetDefaultValues();
            SubscribeToMessaging();
        }

        public bool CanCreate()
        {
            return !attributes.Any(pair => MustSelect(pair.Key));

        }

        public bool MustSelect(CharacterAttributes attribute)
        {
            return CanSelect(attribute) && !IsSelected(attribute);
        }

        public Character Create()
        {
            var raceName = StateManager.GetValue(CharacterAttributes.Race) as string;
            var className = StateManager.GetValue(CharacterAttributes.Class) as string;
            var abilities = StateManager.GetValue(CharacterAttributes.Abilities) as Abilities;
            var name = StateManager.GetValue(CharacterAttributes.Name) as string;
            var backgroundName = StateManager.GetValue(CharacterAttributes.Background) as string;


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
            StateManager.SetValue(CharacterAttributes.Abilities, Abilities.CreateDefault());
        }

        private void SubscribeToMessaging()
        {
            MessagingCenter.Subscribe<object, AttributeSelection>(this,
                MessageTypes.SelectionMade.ToString(), OnSelectionMade);
        }

        private void OnSelectionMade(object sender, AttributeSelection selection)
        {
            StateManager.SetValue(selection.Attribute, selection.Value);
        }

        private bool CanSelect(CharacterAttributes attribute)
        {
            return attributes[attribute]();
        }

        private bool IsSelected(CharacterAttributes attribute)
        {
            return StateManager.HasKey(attribute);
        }

        public bool HasSubRaces()
        {
            if (!IsSelected(CharacterAttributes.Race))
                return false;
            var race = StateManager.GetValue(CharacterAttributes.Race);
            return RepositoryFacade.GetSubraceNames(race.ToString()).Any();
        }
    }
}
