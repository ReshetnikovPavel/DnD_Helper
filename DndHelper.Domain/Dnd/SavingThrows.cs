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
