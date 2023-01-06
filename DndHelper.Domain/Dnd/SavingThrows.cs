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

        public SavingThrows(Abilities abilities, ProficiencyBonus proficiencyBonus)
        {
            Dictionary = new Dictionary<AbilityName, SavingThrow>();
            foreach (var (abilityName, ability) in abilities.Dictionary)
                Dictionary[abilityName] = new SavingThrow(ability, proficiencyBonus);
        }

        public SavingThrow this[AbilityName name]
        {
            get => Dictionary[name];
        }
    }
}
