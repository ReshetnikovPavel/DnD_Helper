using DndHelper.Domain.Dnd;
using DndHelper.Infrastructure;

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
        public int Money => 1000;
        public int HitPoints => 10;
        public int Initiative => 3;
        public Abilities AbilityScores => Abilities.CreateDefault();
        public Skills Skills => Skills.CreateDefault();
        public SavingThrows SavingThrows => SavingThrows.CreateDefault();
        public string Armor => "Leather";
        public List<Weapon> WeaponsProficiencies => new List<Weapon> { new Weapon("Dagger"), new Weapon("Word"), new Weapon("Sword") };
        public List<Instrument> InstrumentProficiencies => new List<Instrument> { new Instrument("палкакопалка"), new Instrument("Паша"), new Instrument("ручка") };
        public List<Armor> ArmorProficiencies => new List<Armor> { new Armor("Кождоспех"), new Armor("металлдоспех"), new Armor("словесный доспех") };
        public List<Weapon> Weapons => new List<Weapon> { new Weapon("Dagger", new Dice(1, DiceName.D4), "кол."), new Weapon("Word", new Dice(1, DiceName.D20), "кол."), new Weapon("Sword", new Dice(1, DiceName.D6), "кол.") };
        public List<Equipment> Equipments => new List<Equipment> { new Equipment("Dagg333er"), new Equipment("Wor333d"), new Equipment("Swor333d") };
        public List<Spell> Spells => new List<Spell> { new Spell("Fireball", 12, new List<SpellComponent>(){SpellComponent.Verbal}, "wolshebnyau", "dohuya", new List<string>(){"Rogue", "Warrior"}), new Spell("Fireball", 12, new List<SpellComponent>(){SpellComponent.Verbal, SpellComponent.Somatic}, "wolshebny", "dohuya", new List<string>(){"Rogue", "Warrior"}), new Spell("Fireball", 12, new List<SpellComponent>(){SpellComponent.Verbal}, "wolshebny", "dohuya", new List<string>(){"Rogue", "Warrior"}) };
        public ProficiencyBonus ProficiencyBonus => new ProficiencyBonus(2);
        public string Languages => "Common, Elvish";
    }

    public class Equipments : ValueType<Equipments>, IDndObject
    {
        public Equipments(Equipment equipment1, Equipment equipment2)
        {
            Equipment1 = equipment1;
            Equipment2 = equipment2;
        }

        public Equipment Equipment1 { get; }
        public Equipment Equipment2 { get; }

        public static Equipments CreateDefault()
        {
            return new Equipments(new Equipment("Dagger"), new Equipment("Word"));
        }
    }

    public class Weapons : ValueType<Weapons>, IDndObject
    {
        public Weapons(Weapon weapon1, Weapon weapon2)
        {
            Weapon1 = weapon1;
            Weapon2 = weapon2;
        }

        public Weapon Weapon1 { get; }
        public Weapon Weapon2 { get; }

        public static Weapons CreateDefault()
        {
            return new Weapons(new Weapon("Dagger", new Dice(1, DiceName.D4), "кол."), new Weapon("Word", new Dice(1, DiceName.D20), "кол."));
        }
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