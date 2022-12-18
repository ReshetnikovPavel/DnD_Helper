using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Domain;

namespace DnD_Helper.ViewModels
{
    class CharacterModel : BindableObject
    {
        public static Character Character { get; set; }
        public string Name = "Anna";
        public int Level = 1;
        public string Class = "Rogue";
        public string Race = "Human";
        public string Background = "Criminal";
        public int Speed = 30;
        public int ArmorClass = 10;
        public int HitPoints = 10;
        public int Initiative = 3;
        public Abilities Abilities = Abilities.CreateDefault();
        public SavingThrow[] SavingThrows = new SavingThrow[6]{new SavingThrow(new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new SavingThrow(new AbilityScore(AbilityName.Dexterity, 13), new ProficiencyBonus(2)), new SavingThrow(new AbilityScore(AbilityName.Constitution, 13), new ProficiencyBonus(2)), new SavingThrow(new AbilityScore(AbilityName.Intelligence, 13), new ProficiencyBonus(2)), new SavingThrow(new AbilityScore(AbilityName.Wisdom, 13), new ProficiencyBonus(2)), new SavingThrow(new AbilityScore(AbilityName.Charisma, 13), new ProficiencyBonus(2))};
        public Skill[] Skills = new Skill[18]{new Skill(SkillName.Acrobatics, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new Skill(SkillName.AnimalHandling, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new Skill(SkillName.Arcana, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new Skill(SkillName.Athletics, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new Skill(SkillName.Deception, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new Skill(SkillName.History, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new Skill(SkillName.Insight, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new Skill(SkillName.Intimidation, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new Skill(SkillName.Investigation, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new Skill(SkillName.Medicine, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new Skill(SkillName.Nature, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new Skill(SkillName.Perception, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new Skill(SkillName.Performance, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new Skill(SkillName.Persuasion, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new Skill(SkillName.Religion, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new Skill(SkillName.SleightOfHand, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new Skill(SkillName.Stealth, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2)), new Skill(SkillName.Survival, new AbilityScore(AbilityName.Strength, 13), new ProficiencyBonus(2))};
    }
}
