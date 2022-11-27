using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IAbilityScoreDistributor
    {
        int TotalPoints { get; set; }

        void BuyAbilityScoreValue(AbilityScore abilityScore);

        int GetPriceToBuy(int value);

        bool CanBuy(AbilityScore abilityScore);

        void SellAbilityScoreValue(AbilityScore abilityScore);

        bool CanSell(AbilityScore abilityScore);

        int GetPriceToSell(int value);

        void ResetTotalPoints();

        public event EventHandler TotalPointsUpdated;
    }
}
