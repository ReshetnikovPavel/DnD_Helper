
using Infrastructure;

namespace DndHelper.Domain.Dnd;

public class DistributorAbilityScore : IAbilityScoreDistributor
{
    private int totalPoints = 27;
    public int TotalPoints
    {
        get => totalPoints;
        set
        {
            totalPoints = value;
            TotalPointsUpdated?.Invoke(this, EventArgs.Empty);
        }
    }

    public void BuyAbilityScoreValue(AbilityScore abilityScore)
    {
        if (CanBuy(abilityScore))
        {
            TotalPoints -= GetPriceToBuy(abilityScore.Value);
            abilityScore.IncreaseValue();
        }
    }
    
    public int GetPriceToBuy(int value)
        => value > 12 ? 2 : 1;

    public bool CanBuy(AbilityScore abilityScore)
        => TotalPoints > 0 && abilityScore.Value < 15 && GetPriceToBuy(abilityScore.Value) <= TotalPoints;

    public void SellAbilityScoreValue(AbilityScore abilityScore)
    {
        if (CanSell(abilityScore))
        {
            TotalPoints += GetPriceToSell(abilityScore.Value);
            abilityScore.DecreaseValue();
        }
    }

    public bool CanSell(AbilityScore abilityScore)
        => abilityScore.Value > 8 && TotalPoints < 27;

    public int GetPriceToSell(int value)
        => value > 13 ? 2 : 1;

    public void ResetTotalPoints() => TotalPoints = 27;

    public event EventHandler TotalPointsUpdated;
}
