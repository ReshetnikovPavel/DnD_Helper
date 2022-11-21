
using Infrastructure;

namespace Domain;

public class DistributorAbilityScore
{
    public int TotalPoints { get; set; } = 27;

    public void BuyAbilityScoreValue(AbilityScore abilityScore)
    {
        if (CanBuy(abilityScore))
        {
            TotalPoints -= GetPriceToBuy(abilityScore.Value);
            abilityScore.IncreaseValue();
        }
    }
    
    private int GetPriceToBuy(int value)
        => value > 12 ? 2 : 1;

    private bool CanBuy(AbilityScore abilityScore)
        => TotalPoints > 0 && abilityScore.Value < 15 && GetPriceToBuy(abilityScore.Value) <= TotalPoints;

    public void SellAbilityScoreValue(AbilityScore abilityScore)
    {
        if (CanSell(abilityScore))
        {
            TotalPoints += GetPriceToSell(abilityScore.Value);
            abilityScore.DecreaseValue();
        }
    }

    private bool CanSell(AbilityScore abilityScore)
        => abilityScore.Value > 8 && TotalPoints < 27;

    private int GetPriceToSell(int value)
        => value > 13 ? 2 : 1;

    public int GetTotalPoints() => TotalPoints;

    public void ResetTotalPoints() => TotalPoints = 27;

    public int[] GetRandomAbilityScoresValues()
    {
        var values = new List<int>();
        for (int i = 0; i < 6; i++)
            values.Add(GetRandomValueAbility());

        return values.ToArray();
    }

    private int GetRandomValueAbility()
    {
        var dice = new Dice(4, DiceName.D6);
        var values = dice.GetRandomValues().ToList();
        values.Remove(values.Min());
        var sum = 0;
        for (var i = 0; i < values.Count; i++)
            sum += values[i];

        return sum;
    }
}
