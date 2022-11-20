using System.ComponentModel;
using Domain.Repositories;
using FluentAssertions;
using NUnit.Framework;

namespace Domain.Tests;

[TestFixture]
public class DndParser_should
{
	private IDndParser parser;
	
	[SetUp]
	public void SetUp()
	{
		parser = new DndCompendiumParser();
	}
	
	[Test]
	[TestCase("T", Size.Tiny)]
	[TestCase("S", Size.Small)]
	[TestCase("M", Size.Medium)]
	[TestCase("L", Size.Large)]
	[TestCase("H", Size.Huge)]
	[TestCase("G", Size.Gargantuan)]
	public void TestParseSize(string stringSize, Size expectedSize)
	{
		var size = parser.ParseSize(stringSize);
		size.Should().Be(expectedSize);
	}
	
	[Test]
	public void TestParseSize_InvalidSize()
	{
		Action act = () => parser.ParseSize("X");
		act.Should().Throw<InvalidEnumArgumentException>();
	}
	
	[Test]
	public void TestSplit()
	{
		parser.Split("L, M, S").Should().BeEquivalentTo("L", "M", "S");
	}

	[Test]
	public void TestParseSpeed()
	{
		parser.ParseSpeed("10").Value.Should().Be(10);
	}

	[Test]
	[TestCase("Str", AbilityName.Strength)]
	[TestCase("Dex", AbilityName.Dexterity)]
	[TestCase("Con", AbilityName.Constitution)]
	[TestCase("Int", AbilityName.Intelligence)]
	[TestCase("Wis", AbilityName.Wisdom)]
	[TestCase("Cha", AbilityName.Charisma)]
	public void TestParseAbilityName(string stringAbilityName, AbilityName expectedAbilityName)
	{
		var abilityName = parser.ParseAbilityName(stringAbilityName);
		abilityName.Should().Be(expectedAbilityName);
	}
	
	[Test]
	public void TestParseAbilityName_InvalidAbilityName()
	{
		Action act = () => parser.ParseAbilityName("X");
		act.Should().Throw<InvalidEnumArgumentException>();
	}

	[Test]
	[TestCase("Str 1", AbilityName.Strength, 1)]
	[TestCase("Dex 2", AbilityName.Dexterity, 2)]
	[TestCase("Con -2", AbilityName.Constitution, -2)]
	public void TestParseAbilityScoreBonus(string stringAbilityScoreBonus, AbilityName expectedAbilityScoreBonus, int expectedBonus)
	{
		var abilityScoreBonus = parser.ParseAbilityScoreBonus(stringAbilityScoreBonus);
		abilityScoreBonus.Name.Should().Be(expectedAbilityScoreBonus);
		abilityScoreBonus.Value.Should().Be(expectedBonus);
	}

	[Test]
	public void TestParseLanguage()
	{
		var name = "Эльфийский";
		var language = parser.ParseLanguage(name);
		language.Name.Should().Be(name);
	}

	[Test]
	public void TestParseWeapon()
	{
		var name = "Короткий меч";
		var language = parser.ParseWeapon(name);
		language.Name.Should().Be(name);
	}

	[Test]
	[TestCase("Внимательность", SkillName.Perception)]
	[TestCase("Выживание", SkillName.Survival)]
	[TestCase("Акробатика", SkillName.Acrobatics)]
	[TestCase("Атлетика", SkillName.Athletics)]
	public void ParseSkillName(string stringSkillName, SkillName expectedSkillName)
	{
		var skillName = parser.ParseSkillName(stringSkillName);
		skillName.Should().Be(expectedSkillName);
	}

	[Test]
	public void ParseSpell()
	{
		var entry = "1: Пляшущие огоньки";
		var spell = parser.ParseSpell(entry);
		spell.Name.Should().Be("Пляшущие огоньки");
		spell.Level.Should().Be(1);
	}
	
	[Test]
	public void TestParseChoiceFrom()
	{
		var (howMany, entries) = parser.ParseChoiceFrom("1: инструменты кузнеца, инструменты пивовара, инструменты каменщинка");
		howMany.Should().Be(1);
		entries.Should().BeEquivalentTo("инструменты кузнеца", "инструменты пивовара", "инструменты каменщинка");
	}

	[Test]
	public void TestParseArmor()
	{
		parser.ParseArmor("Кольчуга").Name.Should().Be("Кольчуга");
	}

	[Test]
	public void TestParseInstrument()
	{
		parser.ParseInstrument("инструменты жестянщика").Name.Should().Be("инструменты жестянщика");
	}
}