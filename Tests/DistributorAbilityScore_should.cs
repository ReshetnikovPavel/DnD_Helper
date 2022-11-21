using Domain;

namespace Tests;

[TestFixture]
public class DistributorAbilityScore_should
{
    [Test]
    [TestCase(8, 9, 26)]
    [TestCase(13, 14, 25)]
    [TestCase(14, 15, 25)]
    public void TestBuyAbilityScoreValue(int value, int answerScore, int answerTotalPoints)
    {
        var score = new AbilityScore(AbilityName.Strength, value);
        DistributorAbilityScore.BuyAbilityScoreValue(score);
        score.Value.Should().Be(answerScore);
        DistributorAbilityScore.GetTotalPoints().Should().Be(answerTotalPoints);
        DistributorAbilityScore.ResetTotalPoints();
    }

    [Test]
    [TestCase(9, 27, 9, 27)]
    [TestCase(14, 25, 13, 27)]
    [TestCase(15, 25, 14, 27)]
    [TestCase(12, 25, 11, 26)]
    [TestCase(8, 25, 8, 25)]
    public void TestSellAbilityScoreValue(int value, int valueTotalPoints, int answerScore, int answerTotalPoints)
    {
        var score = new AbilityScore(AbilityName.Strength, value);
        DistributorAbilityScore.totalPoints = valueTotalPoints;
        DistributorAbilityScore.SellAbilityScoreValue(score);
        score.Value.Should().Be(answerScore);
        DistributorAbilityScore.GetTotalPoints().Should().Be(answerTotalPoints);
        DistributorAbilityScore.ResetTotalPoints();
    }
}