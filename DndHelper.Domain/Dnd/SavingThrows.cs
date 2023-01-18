using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Domain.Dnd
{
    public class SavingThrows
    {
        public Dictionary<AbilityName, SavingThrow> Dictionary { get; }
        public SavingThrow Strength { get => Dictionary[AbilityName.Strength]; }
        public SavingThrow Dexterity { get => Dictionary[AbilityName.Dexterity]; }
        public SavingThrow Constitution { get => Dictionary[AbilityName.Constitution]; }
        public SavingThrow Intelligence { get => Dictionary[AbilityName.Intelligence]; }
        public SavingThrow Wisdom { get => Dictionary[AbilityName.Wisdom]; }
        public SavingThrow Charisma { get => Dictionary[AbilityName.Charisma]; }

        public SavingThrows(SavingThrow strength, SavingThrow dexterity, SavingThrow constitution, SavingThrow intelligence, SavingThrow wisdom, SavingThrow charisma)
        {
            Dictionary = new Dictionary<AbilityName, SavingThrow>
            {
                { AbilityName.Strength, strength },
                { AbilityName.Dexterity, dexterity },
                { AbilityName.Constitution, constitution },
                { AbilityName.Intelligence, intelligence },
                { AbilityName.Wisdom, wisdom },
                { AbilityName.Charisma, charisma }
            };
        }

        public SavingThrow this[AbilityName name]
        {
            get => Dictionary[name];
        }

        public static SavingThrows Create(Abilities abilities, ProficiencyBonus proficiencyBonus)
        {
            var dictionary = new Dictionary<AbilityName, SavingThrow>();
            foreach (var (abilityName, ability) in abilities.Dictionary)
                dictionary[abilityName] = new SavingThrow(ability, proficiencyBonus);
            return new SavingThrows(dictionary[AbilityName.Strength], dictionary[AbilityName.Dexterity], dictionary[AbilityName.Constitution], dictionary[AbilityName.Intelligence], dictionary[AbilityName.Wisdom], dictionary[AbilityName.Charisma]);
        }
    }
}
