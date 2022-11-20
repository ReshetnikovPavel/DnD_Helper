using Domain;

namespace Tests;

[TestFixture]
public class AbilitityScore_should
{
	[Test]
	[TestCase(1, -5)]
	[TestCase(2, -4)]
	[TestCase(3, -4)]
	[TestCase(8, -1)]
	[TestCase(9, -1)]
	[TestCase(10, 0)]
	[TestCase(11, 0)]
	[TestCase(14, 2)]
	[TestCase(15, 2)]
	[TestCase(20, 5)]
	public void TestAbilityScoreModifier(int baseValue, int expectedModifier)
	{
		var score = new AbilityScore(AbilityName.Strength, baseValue);
		score.Modifier.Should().Be(expectedModifier);
	} 
}