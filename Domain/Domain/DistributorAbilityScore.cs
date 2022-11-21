
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
}
