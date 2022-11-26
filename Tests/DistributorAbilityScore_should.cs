using Domain;

namespace Tests;

[TestFixture]
public class DistributorAbilityScore_should
{
    private DistributorAbilityScore distributor;

    [SetUp]
    public void SetUp()
    {
        distributor = new DistributorAbilityScore();
    }

    [Test]
    [TestCase(8, 9, 26)]
    [TestCase(13, 14, 25)]
    [TestCase(14, 15, 25)]
    public void TestBuyAbilityScoreValue(int value, int answerScore, int answerTotalPoints)
    {
        var score = new AbilityScore(AbilityName.Strength, value);
        distributor.BuyAbilityScoreValue(score);
        score.Value.Should().Be(answerScore);
        distributor.GetTotalPoints().Should().Be(answerTotalPoints);
        distributor.ResetTotalPoints();
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
        distributor.TotalPoints = valueTotalPoints;
        distributor.SellAbilityScoreValue(score);
        score.Value.Should().Be(answerScore);
        distributor.GetTotalPoints().Should().Be(answerTotalPoints);
        distributor.ResetTotalPoints();
    }
}