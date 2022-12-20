using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Domain;
using Infrastructure;

namespace DnD_Helper.ViewModels
{
    public class CharacterModel : BindableObject
    {
        public static Character Character { get; set; }
        public string Name => "Anna";
        public int Level => 1;
        public string Class => "Rogue";
        public string Race => "Human";
        public string Background => "Criminal";
        public int Speed => 30;
        public int ArmourClass => 10;
        public int HitPoints => 10;
        public int Initiative => 3;
        public Abilities Abilities => Abilities.CreateDefault();
        public Skills Skills => Skills.CreateDefault();
        public SavingThrows SavingThrows => SavingThrows.CreateDefault();
        // public int[] SavingThrows => new int[6]{1, 2, 3, 4, 5, 6};
        // public int[] Skills => new int[18]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18};

        // private Skill[] GetSkills()
        //     =>  new Skill[18]{new Skill(SkillName.Acrobatics, new AbilityScore(AbilityName.Dexterity, 8), new ProficiencyBonus(2)), new Skill(SkillName.AnimalHandling, new AbilityScore(AbilityName.Wisdom, 8), new ProficiencyBonus(2)), new Skill(SkillName.Arcana, new AbilityScore(AbilityName.Intelligence, 8), new ProficiencyBonus(2)), new Skill(SkillName.Athletics, new AbilityScore(AbilityName.Strength, 8), new ProficiencyBonus(2)), new Skill(SkillName.Deception, new AbilityScore(AbilityName.Charisma, 8), new ProficiencyBonus(2)), new Skill(SkillName.History, new AbilityScore(AbilityName.Intelligence, 8), new ProficiencyBonus(2)), new Skill(SkillName.Insight, new AbilityScore(AbilityName.Wisdom, 8), new ProficiencyBonus(2)), new Skill(SkillName.Intimidation, new AbilityScore(AbilityName.Charisma, 8), new ProficiencyBonus(2)), new Skill(SkillName.Investigation, new AbilityScore(AbilityName.Intelligence, 8), new ProficiencyBonus(2)), new Skill(SkillName.Medicine, new AbilityScore(AbilityName.Wisdom, 8), new ProficiencyBonus(2)), new Skill(SkillName.Nature, new AbilityScore(AbilityName.Intelligence, 8), new ProficiencyBonus(2)), new Skill(SkillName.Perception, new AbilityScore(AbilityName.Wisdom, 8), new ProficiencyBonus(2)), new Skill(SkillName.Performance, new AbilityScore(AbilityName.Charisma, 8), new ProficiencyBonus(2)), new Skill(SkillName.Persuasion, new AbilityScore(AbilityName.Charisma, 8), new ProficiencyBonus(2)), new Skill(SkillName.Religion, new AbilityScore(AbilityName.Intelligence, 8), new ProficiencyBonus(2)), new Skill(SkillName.SleightOfHand, new AbilityScore(AbilityName.Dexterity, 8), new ProficiencyBonus(2)), new Skill(SkillName.Stealth, new AbilityScore(AbilityName.Dexterity, 8), new ProficiencyBonus(2)), new Skill(SkillName.Survival, new AbilityScore(AbilityName.Wisdom, 8), new ProficiencyBonus(2))};

        // private SavingThrow[] GetSavingThrows()
        //     => new SavingThrow[6]{new SavingThrow(new AbilityScore(AbilityName.Strength, 8), new ProficiencyBonus(2)), new SavingThrow(new AbilityScore(AbilityName.Dexterity, 8), new ProficiencyBonus(2)), new SavingThrow(new AbilityScore(AbilityName.Constitution, 8), new ProficiencyBonus(2)), new SavingThrow(new AbilityScore(AbilityName.Intelligence, 8), new ProficiencyBonus(2)), new SavingThrow(new AbilityScore(AbilityName.Wisdom, 8), new ProficiencyBonus(2)), new SavingThrow(new AbilityScore(AbilityName.Charisma, 8), new ProficiencyBonus(2))};
    }

    public class Skills : ValueType<Skills>, IDndObject
    {
        public Skill Acrobatics { get; }
        public Skill AnimalHandling { get; }
        public Skill Arcana { get; }
        public Skill Athletics { get; }
        public Skill Deception { get; }
        public Skill History { get; }
        public Skill Insight { get; }
        public Skill Intimidation { get; }
        public Skill Investigation { get; }
        public Skill Medicine { get; }
        public Skill Nature { get; }
        public Skill Perception { get; }
        public Skill Performance { get; }
        public Skill Persuasion { get; }
        public Skill Religion { get; }
        public Skill SleightOfHand { get; }
        public Skill Stealth { get; }
        public Skill Survival { get; }

        public Skills(Skill acrobatics, Skill animalHandling, Skill arcana, Skill athletics, Skill deception, Skill history, Skill insight, Skill intimidation, Skill investigation, Skill medicine, Skill nature, Skill perception, Skill performance, Skill persuasion, Skill religion, Skill sleightOfHand, Skill stealth, Skill survival)
        {
            Acrobatics = acrobatics;
            AnimalHandling = animalHandling;
            Arcana = arcana;
            Athletics = athletics;
            Deception = deception;
            History = history;
            Insight = insight;
            Intimidation = intimidation;
            Investigation = investigation;
            Medicine = medicine;
            Nature = nature;
            Perception = perception;
            Performance = performance;
            Persuasion = persuasion;
            Religion = religion;
            SleightOfHand = sleightOfHand;
            Stealth = stealth;
            Survival = survival;
        }

        public static Skills CreateDefault()
        {
            return new Skills(new Skill(SkillName.Acrobatics, new AbilityScore(AbilityName.Dexterity, 8), new ProficiencyBonus(2)), new Skill(SkillName.AnimalHandling, new AbilityScore(AbilityName.Wisdom, 8), new ProficiencyBonus(2)), new Skill(SkillName.Arcana, new AbilityScore(AbilityName.Intelligence, 8), new ProficiencyBonus(2)), new Skill(SkillName.Athletics, new AbilityScore(AbilityName.Strength, 8), new ProficiencyBonus(2)), new Skill(SkillName.Deception, new AbilityScore(AbilityName.Charisma, 8), new ProficiencyBonus(2)), new Skill(SkillName.History
                , new AbilityScore(AbilityName.Intelligence, 8), new ProficiencyBonus(2)), new Skill(SkillName.Insight, new AbilityScore(AbilityName.Wisdom, 8), new ProficiencyBonus(2)), new Skill(SkillName.Intimidation, new AbilityScore(AbilityName.Charisma, 8), new ProficiencyBonus(2)), new Skill(SkillName.Investigation, new AbilityScore(AbilityName.Intelligence, 8), new ProficiencyBonus(2)), new Skill(SkillName.Medicine, new AbilityScore(AbilityName.Wisdom, 8), new ProficiencyBonus(2)), new Skill(SkillName.Nature, new AbilityScore(AbilityName.Intelligence, 8), new ProficiencyBonus(2)), new Skill(SkillName.Perception, new AbilityScore(AbilityName.Wisdom, 8), new ProficiencyBonus(2)), new Skill(SkillName.Performance, new AbilityScore(AbilityName.Charisma, 8), new ProficiencyBonus(2)), new Skill(SkillName.Persuasion, new AbilityScore(AbilityName.Charisma, 8), new ProficiencyBonus(2)), new Skill(SkillName.Religion, new AbilityScore(AbilityName.Intelligence, 8), new ProficiencyBonus(2)), new Skill(SkillName.SleightOfHand, new AbilityScore(AbilityName.Dexterity, 8), new ProficiencyBonus(2)), new Skill(SkillName.Stealth, new AbilityScore(AbilityName.Dexterity, 8), new ProficiencyBonus(2)), new Skill(SkillName.Survival, new AbilityScore(AbilityName.Wisdom, 8), new ProficiencyBonus(2)));
        }
    }

    public class SavingThrows : ValueType<SavingThrows>, IDndObject
    {
        public SavingThrow Strength { get; }
        public SavingThrow Dexterity { get; }
        public SavingThrow Constitution { get; }
        public SavingThrow Intelligence { get; }
        public SavingThrow Wisdom { get; }
        public SavingThrow Charisma { get; }

        public SavingThrows(SavingThrow strength, SavingThrow dexterity, SavingThrow constitution, SavingThrow intelligence, SavingThrow wisdom, SavingThrow charisma)
        {
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
        }

        public static SavingThrows CreateDefault()
        {
            return new SavingThrows(new SavingThrow(new AbilityScore(AbilityName.Strength, 8), new ProficiencyBonus(2)), new SavingThrow(new AbilityScore(AbilityName.Dexterity, 8), new ProficiencyBonus(2)), new SavingThrow(new AbilityScore(AbilityName.Constitution, 8), new ProficiencyBonus(2)), new SavingThrow(new AbilityScore(AbilityName.Intelligence, 8), new ProficiencyBonus(2)), new SavingThrow(new AbilityScore(AbilityName.Wisdom, 8), new ProficiencyBonus(2)), new SavingThrow(new AbilityScore(AbilityName.Charisma, 8), new ProficiencyBonus(2)));
        }
    }
}

