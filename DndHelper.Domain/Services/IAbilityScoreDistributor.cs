
/* Unmerged change from project 'DndHelper.Domain (net6.0-maccatalyst)'
Before:
using System;
After:
using DndHelper.Domain.Dnd;
using System;
*/

/* Unmerged change from project 'DndHelper.Domain (net6.0-ios)'
Before:
using System;
After:
using DndHelper.Domain.Dnd;
using System;
*/

/* Unmerged change from project 'DndHelper.Domain (net6.0-android)'
Before:
using System;
After:
using DndHelper.Domain.Dnd;
using System;
*/

/* Unmerged change from project 'DndHelper.Domain (net6.0-windows10.0.19041.0)'
Before:
using System;
After:
using DndHelper.Domain.Dnd;
using System;
*/
using
/* Unmerged change from project 'DndHelper.Domain (net6.0-maccatalyst)'
Before:
using System.Threading.Tasks;
using DndHelper.Domain.Dnd;
After:
using System.Threading.Tasks;
*/

/* Unmerged change from project 'DndHelper.Domain (net6.0-ios)'
Before:
using System.Threading.Tasks;
using DndHelper.Domain.Dnd;
After:
using System.Threading.Tasks;
*/

/* Unmerged change from project 'DndHelper.Domain (net6.0-android)'
Before:
using System.Threading.Tasks;
using DndHelper.Domain.Dnd;
After:
using System.Threading.Tasks;
*/

/* Unmerged change from project 'DndHelper.Domain (net6.0-windows10.0.19041.0)'
Before:
using System.Threading.Tasks;
using DndHelper.Domain.Dnd;
After:
using System.Threading.Tasks;
*/
DndHelper.Domain.Dnd;

namespace DndHelper.Domain.Services;
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

