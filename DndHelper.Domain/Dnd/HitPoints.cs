using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class HitPoints : ValueType<HitDice>, IDndObject
{
    public int Current { get; }
    public int Maximum { get; }
    public int Temporary { get; }

    public HitPoints(int maximum)
    {
        Maximum = maximum;
        Current = maximum;
        Temporary = 0;
    }
}