
using Infrastructure;

namespace Domain;

public static class DistributorAbilityScore
{
    public static int totalPoints = 27;
    public static void BuyAbilityScoreValue(AbilityScore abilityScore)
    {
        if (totalPoints > 0 && abilityScore.Value < 15)
        {
            if (abilityScore.Value > 12)
            {
                if (totalPoints > 1)
                {
                    abilityScore.IncreaseValue();
                    totalPoints -= 2;
                }
            }
            else
            {
                abilityScore.IncreaseValue();
                totalPoints--;
            }
        }
    }

    public static void SellAbilityScoreValue(AbilityScore abilityScore)
    {
        if (abilityScore.Value > 8 && totalPoints < 27)
        {
            if (abilityScore.Value > 13)
            {
                abilityScore.DecreaseValue();
                totalPoints += 2;
            }
            else
            {
                abilityScore.DecreaseValue();
                totalPoints++;
            }
        }
    }

    public static int GetTotalPoints() => totalPoints;

    public static void ResetTotalPoints() => totalPoints = 27;
}
