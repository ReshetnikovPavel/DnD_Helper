using DndHelper.Domain;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            foreach(var attribute in Enum.GetValues(typeof(CharacterAttributes)).Cast<CharacterAttributes>())
            {
                if (MustSelect(attribute))
                    return false;
            }
            return true;
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
            var subRaceName = GetSubrace();

            var character = Character.CreateNew(abilities);
            character.ApplyRace(RepositoryFacade.GetRace(raceName, subRaceName));
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
            MessagingCenter.Subscribe<object, CharacterAttributes>(this,
                MessageTypes.AttributeRequested.ToString(), OnAttributeRequested);
        }

        private void OnSelectionMade(object sender, AttributeSelection selection)
        {
            StateManager.SetValue(selection.Attribute, selection.Value);
        }

        private void OnAttributeRequested(object sender, CharacterAttributes attribute)
        {
            MessageSender.SendSelectionMade(this, attribute, StateManager.GetValue(attribute));
        }

        public bool CanSelect(CharacterAttributes attribute)
        {
            switch(attribute)
            {
                case CharacterAttributes.Race:
                    return true;
                case CharacterAttributes.Class:
                    return true;
                case CharacterAttributes.Abilities:
                    return true;
                case CharacterAttributes.Name:
                    return true;
                case CharacterAttributes.Background: 
                    return true;
                case CharacterAttributes.Subrace:
                    return HasSubRaces();
                case CharacterAttributes.Skills:
                    return true;
                //case CharacterAttributes.RaceAbilityBonus:
                //    return HasAbilityBonus();
                //case CharacterAttributes.Languages:
                //    return HasLanguages();
                default:
                    return false;
            }
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

        public bool HasLanguages()
        {
            if(!IsSelected(CharacterAttributes.Race) || MustSelect(CharacterAttributes.Subrace))
                return false;
            var raceName = StateManager.GetValue(CharacterAttributes.Race).ToString();
            var subraceName = GetSubrace();
            var race = RepositoryFacade.GetRace(raceName, subraceName);
            return race.Optionals.Languages is not null;
        }

        public bool HasAbilityBonus()
        {
            if (!IsSelected(CharacterAttributes.Race) || MustSelect(CharacterAttributes.Subrace))
                return false;
            var raceName = StateManager.GetValue(CharacterAttributes.Race).ToString();
            var subraceName = GetSubrace();
            var race = RepositoryFacade.GetRace(raceName, subraceName);
            return race.Optionals.AbilityScoreBonuses is not null;
        }

        private string GetSubrace()
        {
            return IsSelected(CharacterAttributes.Subrace) ?
                StateManager.GetValue(CharacterAttributes.Subrace) as string : null;
        }
    }
}
