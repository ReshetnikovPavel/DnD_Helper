using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Domain.Dnd
{
    public class Skills
    {
        public Dictionary<SkillName, Skill> Dictionary { get; }

        public Skill Acrobatics { get => Dictionary[SkillName.Acrobatics]; }
        public Skill AnimalHandling { get => Dictionary[SkillName.AnimalHandling]; }
        public Skill Arcana { get => Dictionary[SkillName.Arcana]; }
        public Skill Athletics { get => Dictionary[SkillName.Athletics]; }
        public Skill Deception { get => Dictionary[SkillName.Deception]; }
        public Skill History { get => Dictionary[SkillName.History]; }
        public Skill Insight { get => Dictionary[SkillName.Insight]; }
        public Skill Intimidation { get => Dictionary[SkillName.Intimidation]; }
        public Skill Investigation { get => Dictionary[SkillName.Investigation]; }
        public Skill Medicine { get => Dictionary[SkillName.Medicine]; }
        public Skill Nature { get => Dictionary[SkillName.Nature]; }
        public Skill Perception { get => Dictionary[SkillName.Perception]; }
        public Skill Performance { get => Dictionary[SkillName.Performance]; }
        public Skill Persuasion { get => Dictionary[SkillName.Persuasion]; }
        public Skill Religion { get => Dictionary[SkillName.Religion]; }
        public Skill SleightOfHand { get => Dictionary[SkillName.SleightOfHand]; }
        public Skill Stealth { get => Dictionary[SkillName.Stealth]; }
        public Skill Survival { get => Dictionary[SkillName.Acrobatics]; }

        private Skills(Abilities abilities, ProficiencyBonus proficiencyBonus)
        {
            Dictionary = new Dictionary<SkillName, Skill>();
            foreach (var skillName in Enum.GetValues<SkillName>())
            {
                var abilityName = AbilityScore.GetNameFromSkillName(skillName);
                Dictionary[skillName] = new Skill(skillName, abilities[abilityName], proficiencyBonus);
            }
        }

        public Skills(Skill acrobatics, Skill animalHandling, Skill arcana, Skill athletics, Skill deception, Skill history, Skill insight, Skill intimidation, Skill investigation, Skill medicine, Skill nature, Skill perception, Skill performance, Skill persuasion, Skill religion, Skill sleightOfHand, Skill stealth, Skill survival)
        {
            Dictionary = new Dictionary<SkillName, Skill>();
            Dictionary[SkillName.Acrobatics] = acrobatics;
            Dictionary[SkillName.AnimalHandling] = animalHandling;
            Dictionary[SkillName.Arcana] = arcana;
            Dictionary[SkillName.Athletics] = athletics;
            Dictionary[SkillName.Deception] = deception;
            Dictionary[SkillName.History] = history;
            Dictionary[SkillName.Insight] = insight;
            Dictionary[SkillName.Intimidation] = intimidation;
            Dictionary[SkillName.Investigation] = investigation;
            Dictionary[SkillName.Medicine] = medicine;
            Dictionary[SkillName.Nature] = nature;
            Dictionary[SkillName.Perception] = perception;
            Dictionary[SkillName.Performance] = performance;
            Dictionary[SkillName.Persuasion] = persuasion;
            Dictionary[SkillName.Religion] = religion;
            Dictionary[SkillName.SleightOfHand] = sleightOfHand;
            Dictionary[SkillName.Stealth] = stealth;
            Dictionary[SkillName.Survival] = survival;
        }

        public Skill this[SkillName skillName]
        {
            get => Dictionary[skillName];
        }

        public static Skills Create(Abilities abilities, ProficiencyBonus proficiencyBonus)
        {
            return new Skills(abilities, proficiencyBonus);
        }
    }
}
