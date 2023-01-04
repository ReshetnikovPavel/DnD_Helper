using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Domain.Dnd
{
    public class Skills
    {
        public Dictionary<SkillName, Skill> Dictionary { get; }

        public Skills(Abilities abilities, ProficiencyBonus proficiencyBonus)
        {
            Dictionary = new Dictionary<SkillName, Skill>();
            foreach (var skillName in Enum.GetValues<SkillName>())
            {
                var abilityName = AbilityScore.GetNameFromSkillName(skillName);
                Dictionary[skillName] = new Skill(skillName, abilities[abilityName], proficiencyBonus);
            }
        }

        public Skill this[SkillName skillName]
        {
            get => Dictionary[skillName];
        }
    }
}
